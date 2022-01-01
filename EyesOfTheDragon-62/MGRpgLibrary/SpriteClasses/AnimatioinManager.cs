using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGRpgLibrary.SpriteClasses
{
    public sealed class AnimationManager
    {
        private static readonly AnimationManager instance = new AnimationManager();
        private readonly Dictionary<AnimationKey, Animation> animations = new
            Dictionary<AnimationKey, Animation>();
    
        public static AnimationManager Instance
        {
            get { return instance; }
        }
        
        public Dictionary<AnimationKey, Animation> Animations
        {
            get { return animations; }
        }
        
        private AnimationManager()
        {
            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);
        
            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);
            
            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);
            
            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);
        }
    }
}
