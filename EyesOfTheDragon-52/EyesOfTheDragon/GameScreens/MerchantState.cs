using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EyesOfTheDragon.Components;
using MGRpgLibrary.CharacterClasses;
using EyesOfTheDragon.GameScreens;
using MGRpgLibrary.ConversationComponents;
using MGRpgLibrary;

namespace EyesOfTheDragon.GameScenes
{
    public interface IMerchantState
    {
        void SetMerchant(Player p, Character c);
        void ShowBuyItems();
        void ShowSellItems();
    }

    public enum MerchantMode
    {
        Talk,
        Sell,
        Buy
    }

    public class MerchantState : BaseGameState, IMerchantState
    {
        private const string titleBuy = "Browsing Merachant's Wares";
        private const string titleSell = "Selling to Merchant";
        private const string item = "Items";
        private const string availableStr = "Available";
        private const string amountStr = "Amount";
        private const string goldStr = "Gold: ";

        private bool mouseOver;

        private Character _merchant;
        private MerchantMode _mode = MerchantMode.Talk;
        private Texture2D _portrait;
        private Texture2D _selected;
        private SpriteFont _merchantFont;
        private ConversationManager _conversationManager = ConversationManager.Instance;
        private Conversation _conversation;
        private MerchantManager _merchantManager = MerchantManager.Instance;
        private MerchantInventory _inventory;
        private InventoryManager _inventoryManager = InventoryManager.Instance;
        private int _selectedIndex = 0;
        private string _selectedItem = "";

        private Color _normalColor = Color.Azure;
        private Color _highlightColor = Color.Red;
        private SpriteFont _sceneFont;

        public Color NormalColor
        {
            get { return _normalColor; }
            set { _normalColor = value; }
        }

        public Color HighlightColor
        {
            get { return _highlightColor; }
            set { _highlightColor = value; }
        }

        public MerchantState(Game game, GameStateManager manager) 
            : base(game, manager)     
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            if (!TextureManager.ContainsTexture("merchant"))
                TextureManager.AddTexture("merchant", GameRef.Content.Load<Texture2D>(@"Backgrounds\merchant-overlay"));

            if (!TextureManager.ContainsTexture("scene-background"))
                TextureManager.AddTexture("scene-background", GameRef.Content.Load<Texture2D>(@"Scenes\scenebackground"));

            _merchantFont = GameRef.Content.Load<SpriteFont>(@"Fonts\Sansation_Light");
            _sceneFont = GameRef.Content.Load<SpriteFont>(@"Fonts\Sansation_Light");

            _selected = GameRef.Content.Load<Texture2D>(@"Misc\selected");

            if (GameScene.Selected == null)
                GameScene.Load(GameRef);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            PlayerIndex index = PlayerIndex.One;
            int i = 0;

            switch (_mode)
            {
                case MerchantMode.Talk :
                    _conversation.Update(gameTime);

                    if (Xin.WasReleased(PlayerIndexInControl, Buttons.A, Keys.Space, out index) || Xin.WasReleased(PlayerIndexInControl, Buttons.A, Keys.Space, out index))
                    {
                        if (_conversation.CurrentScene.OptionAction.Action == ActionType.Buy)
                            _mode = MerchantMode.Buy;
                        if (_conversation.CurrentScene.OptionAction.Action == ActionType.Sell)
                            _mode = MerchantMode.Sell;
                        if (_conversation.CurrentScene.OptionAction.Action == ActionType.End)
                            _manager.PopState();
                    }
                    else if (Xin.CheckMouseReleased(MouseButton.Left) && _conversation.CurrentScene.IsMouseOver)
                    {
                        if (_conversation.CurrentScene.OptionAction.Action == ActionType.Buy)
                            _mode = MerchantMode.Buy;
                        if (_conversation.CurrentScene.OptionAction.Action == ActionType.Sell)
                            _mode = MerchantMode.Sell;
                        if (_conversation.CurrentScene.OptionAction.Action == ActionType.End)
                            _manager.PopState();
                    }
                    break;
                case MerchantMode.Buy :
                    if (Xin.WasReleased(PlayerIndexInControl, Buttons.A, Keys.Space, out index) || (Xin.CheckMouseReleased(MouseButton.Left) && mouseOver))
                    {
                        if (_inventoryManager.ItemList[_selectedItem].Cost <= player.Gold)
                        {
                            player.AddItem(_selectedItem);
                            player.UpdateGold(_inventoryManager.ItemList[_selectedItem].Cost * -1);
                            player.Character.AddItem(_inventoryManager.ItemList[_selectedItem]);
                            _inventory.RemoveItem(_selectedItem);

                            foreach (string s in player.ActiveQuests.Keys)
                            {
                                if (player.ActiveQuests[s].CurrentStep.QuestStepType == QuestStepType.Buy &&
                                    player.ActiveQuests[s].CurrentStep.Target == Enum.GetName(typeof(ItemCategory), _inventoryManager.ItemList[_selectedItem].ItemType))
                                {
                                    player.ActiveQuests[s].CurrentStep.Finish();
                                    player.ActiveQuests[s].UpdateQuestStep();
                                }
                            }
                        }
                        else
                        {
                            // show that the offer was refused
                        }
                    }
                    else if (Xin.WasReleased(PlayerIndexInControl, Buttons.Back, Keys.Escape, out index) || Xin.CheckMouseReleased(MouseButton.Right))
                    {
                        _mode = MerchantMode.Talk;
                    }
                    else if (!mouseOver)
                    { 
                        if (Xin.WasReleased(PlayerIndexInControl, Buttons.LeftThumbstickUp, Keys.Up, out index))
                        {
                            _selectedIndex--;

                            if (_selectedIndex < 0)
                                _selectedIndex = _inventory.Inventory.Count - 1;

                        }
                        else if (Xin.WasReleased(PlayerIndexInControl, Buttons.LeftThumbstickDown, Keys.Down, out index))
                        {
                            _selectedIndex++;

                            if (_selectedIndex >= _inventory.Inventory.Count)
                                _selectedIndex = 0;
                        }
                    }

                    foreach (string s in _inventory.Inventory.Keys)
                    {
                        if (_selectedIndex == i)
                        {
                            _selectedItem = s;
                            break;
                        }
                        i++;
                    }
                    break;
                case MerchantMode.Sell :
                    if (Xin.WasReleased(PlayerIndexInControl, Buttons.A, Keys.Space, out index) || (Xin.CheckMouseReleased(MouseButton.Left) && mouseOver))
                    {
                        player.RemoveItem(_selectedItem);
                        player.UpdateGold(_inventoryManager.ItemList[_selectedItem].Cost / 2);
                        _inventory.AddItem(_selectedItem);

                        foreach (string s in player.ActiveQuests.Keys)
                        {
                            if (player.ActiveQuests[s].CurrentStep.QuestStepType == QuestStepType.Sell &&
                                player.ActiveQuests[s].CurrentStep.Target == Enum.GetName(typeof(ItemCategory), _inventoryManager.ItemList[_selectedItem].ItemType))
                            {
                                player.ActiveQuests[s].CurrentStep.Finish();
                                player.ActiveQuests[s].UpdateQuestStep();
                            }
                        }
                    }
                    else if (Xin.WasReleased(PlayerIndexInControl, Buttons.Back, Keys.Escape, out index) || Xin.CheckMouseReleased(MouseButton.Right))
                    {
                        _mode = MerchantMode.Talk;
                    }
                    else if (!mouseOver)
                    { 
                        if (Xin.WasReleased(PlayerIndexInControl, Buttons.LeftThumbstickUp, Keys.Up, out index))
                        {
                            _selectedIndex--;

                            if (_selectedIndex < 0)
                                _selectedIndex = _inventory.Inventory.Count - 1;

                        }
                        else if (Xin.WasReleased(PlayerIndexInControl, Buttons.LeftThumbstickDown, Keys.Down, out index))
                        {
                            _selectedIndex++;

                            if (_selectedIndex >= _inventory.Inventory.Count)
                                _selectedIndex = 0;
                        }
                    }

                    foreach (string s in player.Backpack.Keys)
                    {
                        if (_selectedIndex == i)
                        {
                            _selectedItem = s;
                            break;
                        }
                        i++;
                    }
                    break;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 itemLocation = new Vector2(175, 110);
            Vector2 length = Vector2.Zero;
            Vector2 titlePos = Vector2.Zero;
            Vector2 goldPos = Vector2.Zero;

            int headingY = 35;
            int availableX = 275;
            int amountX = 400;
            int availableWidth = (int)_merchantFont.MeasureString("Available").X;
            int amountWidth = (int)_merchantFont.MeasureString("Amount").X;
            int i;

            Point mouseLocation = Xin.MouseAsPoint;
            mouseOver = false;

            base.Draw(gameTime);

            switch (_mode)
            {
                case MerchantMode.Talk :
                    GameRef.SpriteBatch.Begin();
                    _conversation.Draw(gameTime, GameRef.SpriteBatch, TextureManager.GetTexture("scene-background"), _sceneFont, _portrait);
                    GameRef.SpriteBatch.End();
                    break;
                case MerchantMode.Buy :
                    GameRef.SpriteBatch.Begin();
                    GameRef.SpriteBatch.Draw(TextureManager.GetTexture("base-background"), Vector2.Zero, Color.White);
                    GameRef.SpriteBatch.Draw(TextureManager.GetTexture("merchant"), Game1.ScreenRectangle, Color.White);

                    length = _merchantFont.MeasureString(titleBuy);

                    titlePos = new Vector2((Game1.ScreenRectangle.Width - length.X) / 2, 10);
                    GameRef.SpriteBatch.DrawString(_merchantFont, titleBuy, titlePos, Color.Azure);

                    GameRef.SpriteBatch.DrawString(_merchantFont, item, new Vector2(itemLocation.X, itemLocation.Y - headingY), Color.Black);
                    GameRef.SpriteBatch.DrawString(_merchantFont, availableStr, new Vector2(itemLocation.X + availableX, itemLocation.Y - headingY), Color.Black);
                    GameRef.SpriteBatch.DrawString(_merchantFont, amountStr, new Vector2(itemLocation.X + amountX, itemLocation.Y - headingY), Color.Black);

                    i = 0;

                    foreach (string s in _inventory.Inventory.Keys)
                    {
                        Rectangle area = new Rectangle((int)itemLocation.X, (int)itemLocation.Y, (amountX + amountWidth) - (int)itemLocation.X, _merchantFont.LineSpacing);

                        if (area.Contains(mouseLocation))
                        {
                            _selectedIndex = i;
                            mouseOver = true;
                        }

                        Color itemColor = NormalColor;

                        if (_selectedIndex == i)
                        {
                            itemColor = HighlightColor;
                            GameRef.SpriteBatch.Draw(_selected, new Vector2(itemLocation.X - 50, itemLocation.Y), Color.White);
                        }

                        GameRef.SpriteBatch.DrawString(_merchantFont, s, itemLocation, itemColor);

                        int paddingX = (availableWidth - (int)_merchantFont.MeasureString(_inventory.Inventory[s].ToString()).X) / 2;
                        GameRef.SpriteBatch.DrawString(_merchantFont, _inventory.Inventory[s].ToString(), new Vector2(itemLocation.X + availableX + paddingX, itemLocation.Y), itemColor);

                        paddingX = (amountWidth - (int)_merchantFont.MeasureString(_inventory.Inventory[s].ToString()).X) / 2;
                        GameRef.SpriteBatch.DrawString(_merchantFont, _inventoryManager.ItemList[s].Cost.ToString(), new Vector2(itemLocation.X + amountX + paddingX, itemLocation.Y), itemColor);

                        itemLocation.Y += _merchantFont.LineSpacing + 5;
                        i++;
                    }

                    goldPos = new Vector2((Game1.ScreenRectangle.Width - _merchantFont.MeasureString(goldStr + player.Gold.ToString()).X) / 2, Game1.ScreenRectangle.Height - _merchantFont.LineSpacing - 5);
                    GameRef.SpriteBatch.DrawString(_merchantFont, goldStr + player.Gold.ToString(), goldPos, Color.Azure);
                    GameRef.SpriteBatch.End();
                    break;
                case MerchantMode.Sell :
                    GameRef.SpriteBatch.Begin();
                    GameRef.SpriteBatch.Draw(TextureManager.GetTexture("base-background"), Vector2.Zero, Color.White);
                    GameRef.SpriteBatch.Draw(TextureManager.GetTexture("merchant"), Game1.ScreenRectangle, Color.White);

                    length = _merchantFont.MeasureString(titleBuy);

                    titlePos = new Vector2((Game1.ScreenRectangle.Width - length.X) / 2, 10);
                    GameRef.SpriteBatch.DrawString(_merchantFont, titleBuy, titlePos, Color.Azure);

                    GameRef.SpriteBatch.DrawString(_merchantFont, item, new Vector2(itemLocation.X, itemLocation.Y - headingY), Color.Black);
                    GameRef.SpriteBatch.DrawString(_merchantFont, availableStr, new Vector2(itemLocation.X + availableX, itemLocation.Y - headingY), Color.Black);
                    GameRef.SpriteBatch.DrawString(_merchantFont, amountStr, new Vector2(itemLocation.X + amountX, itemLocation.Y - headingY), Color.Black);

                    i = 0;

                    foreach (Item s in Character.Backpack)
                    {
                        Rectangle area = new Rectangle((int)itemLocation.X, (int)itemLocation.Y, (amountX + amountWidth) - (int)itemLocation.X, _merchantFont.LineSpacing);

                        if (area.Contains(mouseLocation))
                        {
                            _selectedIndex = i;
                            mouseOver = true;
                        }

                        Color itemColor = NormalColor;

                        if (_selectedIndex == i)
                        {
                            itemColor = HighlightColor;
                            GameRef.SpriteBatch.Draw(_selected, new Vector2(itemLocation.X - 50, itemLocation.Y), Color.White);
                        }

                        GameRef.SpriteBatch.DrawString(_merchantFont, s.Name, itemLocation, itemColor);

                        int paddingX = (availableWidth - (int)_merchantFont.MeasureString(s.Cost.ToString()).X) / 2;
                        GameRef.SpriteBatch.DrawString(_merchantFont, s.Count.ToString(), new Vector2(itemLocation.X + availableX + paddingX, itemLocation.Y), itemColor);

                        paddingX = (amountWidth - (int)_merchantFont.MeasureString(s.Cost.ToString()).X) / 2;
                        GameRef.SpriteBatch.DrawString(_merchantFont, (s.Cost / 2).ToString(), new Vector2(itemLocation.X + amountX + paddingX, itemLocation.Y), itemColor);

                        itemLocation.Y += _merchantFont.LineSpacing + 5;
                        i++;
                    }

                    goldPos = new Vector2((Game1.ScreenRectangle.Width - _merchantFont.MeasureString(goldStr + player.Gold.ToString()).X) / 2, Game1.ScreenRectangle.Height - _merchantFont.LineSpacing - 5);
                    GameRef.SpriteBatch.DrawString(_merchantFont, goldStr + player.Gold.ToString(), goldPos, Color.Azure);
                    GameRef.SpriteBatch.End();
                    break;
            }
        }

        public void SetMerchant(Player p, Character c)
        {
            _merchant = c;

            _conversationManager.ClearConversations();

            Conversations list = GameRef.Content.Load<Conversations>(@"SilverProphet\MerchantConversations\" + _merchant.Name);
            _conversation = list.ConversationList[_merchant.Name];

            if (!_merchantManager.ContainsMerchant(_merchant.Name))
                _inventory = GameRef.Content.Load<MerchantInventory>(@"SilverProphet\MerchantInventories\" + _merchant.Name);
            else
                _inventory = _merchantManager.GetMerchant(_merchant.Name);

            player = p;
            _portrait = c.Portrait;

            _mode = MerchantMode.Talk;

            _selectedIndex = 0;
            _selectedItem = "";

            _conversation.StartConversation();
        }

        public void ShowBuyItems()
        {
        }

        public void ShowSellItems()
        {
        }

        public Player player { get; set; }
    }
}
