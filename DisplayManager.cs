using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace agartha {

public class DisplayManager {

    public Core core;

    public GraphicsDeviceManager device;
    public SpriteBatch sprite_batch;

    RenderTarget2D logical_display;
    Rectangle destination_rectangle;

    public void get_physical_display() {

        device = new GraphicsDeviceManager(core);

        device.PreferredBackBufferHeight = 672;
        device.PreferredBackBufferWidth = 672;
        device.SynchronizeWithVerticalRetrace = false;

    return; }

    public void get_logical_display() {

        logical_display = new RenderTarget2D(
            core.GraphicsDevice, 240, 240);

        destination_rectangle = new Rectangle(
            -48, -48, 720, 720);

        sprite_batch = new SpriteBatch(core.GraphicsDevice);

    return; }

    public void begin() {

        core.GraphicsDevice.SetRenderTarget(logical_display);
        core.GraphicsDevice.Clear(Color.Cyan);
        
        sprite_batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            core.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;

    return; }

    public void end() { sprite_batch.End(); return; }

    public void draw() {

        core.GraphicsDevice.SetRenderTarget(null);

        sprite_batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            core.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
            sprite_batch.Draw((Texture2D)logical_display,
                destination_rectangle, Color.White);
            
        sprite_batch.End();

    return; }
}}