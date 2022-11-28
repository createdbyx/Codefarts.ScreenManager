// <copyright file="ScreenManager.cs" company="Codefarts">
// Copyright (c) Codefarts
// contact@codefarts.com
// http://www.codefarts.com
// </copyright>

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Codefarts.ScreenManager
{
    /// <summary>
    /// The screen manager is a component which manages one or more GameScreen
    /// instances. It maintains a stack of screens, calls their Update and Draw
    /// methods at the appropriate times, and automatically routes input to the
    /// topmost active screen.
    /// </summary>
    public interface IScreenManager
    {
        /// <summary>
        /// A default SpriteBatch shared by all the screens. This saves
        /// each screen having to bother creating their own local instance.
        /// </summary>
        public SpriteBatch SpriteBatch { get; }
                                                    
        /// <summary>
        /// A default font shared by all the screens. This saves
        /// each screen having to bother loading their own local copy.
        /// </summary>
        public SpriteFont DefaultFont { get; set; }

        /// <summary>
        /// Initializes the screen manager component.
        /// </summary>
        public void Initialize();

        /// <summary>
        /// Allows each screen to run logic.
        /// </summary>
        public void Update(GameTime gameTime);

        /// <summary>
        /// Tells each screen to draw itself.
        /// </summary>
        public void Draw(GameTime gameTime);

        /// <summary>
        /// Adds a new screen to the screen manager.
        /// </summary>
        public void AddScreen(IGameScreen screen, PlayerIndex? controllingPlayer);

        /// <summary>
        /// Removes a screen from the screen manager. You should normally
        /// use GameScreen.ExitScreen instead of calling this directly, so
        /// the screen can gradually transition off rather than just being
        /// instantly removed.
        /// </summary>
        public void RemoveScreen(IGameScreen screen);

        /// <summary>
        /// Expose an array holding all the screens. We return a copy rather
        /// than the real master list, because screens should only ever be added
        /// or removed using the AddScreen and RemoveScreen methods.
        /// </summary>
        public IGameScreen[] GetScreens();
    }
}