using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace agartha {

public class Core : Microsoft.Xna.Framework.Game {

    double elapsed_time, delay_current;
    int render_cycle;

    public DisplayManager display_manager;
    public PatternManager pattern_manager;
    public SpriteManager sprite_manager;
    public NPCManager npc_manager;

    public Matrix matrix;
    public NameTable nametable;

    public Parallax parallax;
    public Viewport viewport;

    public _level_alpha level_alpha;
    public BoundaryManager boundary_manager;

    public Core() {

        Content.RootDirectory = "Content";
        IsFixedTimeStep = false;

        display_manager = new DisplayManager();
        pattern_manager = new PatternManager();
        sprite_manager = new SpriteManager();
        npc_manager = new NPCManager();

        parallax = new Parallax();
        nametable = new NameTable();
        viewport = new Viewport();

        display_manager.core = this;
        display_manager.get_physical_display();

        boundary_manager = new BoundaryManager();

        render_cycle = 0;
        delay_current = 0;

    return; }

    protected override void Initialize() {

        display_manager.get_logical_display();

        pattern_manager.initialize(this);
        sprite_manager.initialize(this);

        boundary_manager.initialize(this);
        npc_manager.initialize(this);

        parallax.initialize(this);
        nametable.initialize(this);
        viewport.initialize(this);

        level_alpha = new _level_alpha();
        level_alpha.initialize(this);

    base.Initialize(); }

    protected override void LoadContent() {
    
        pattern_manager.load();

    return; }

    protected override void UnloadContent() { return; }

    public bool delay() {
 
        if (elapsed_time-delay_current < 1) return false;
        delay_current = elapsed_time;

    return true; }

    protected override void Update(GameTime gameTime) {
    
        elapsed_time = (double)gameTime.TotalGameTime.TotalMilliseconds;
        if (delay() == false) return;
    
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
    
        level_alpha.playable_kuros.direction.next_x = Direction.idle;
        level_alpha.playable_kuros.direction.next_y = Direction.idle;

        if (Keyboard.GetState().IsKeyDown(Keys.A))
        level_alpha.playable_kuros.direction.next_x = Direction.left;

        else if (Keyboard.GetState().IsKeyDown(Keys.D))
        level_alpha.playable_kuros.direction.next_x = Direction.right;

        if (Keyboard.GetState().IsKeyDown(Keys.W))
        level_alpha.playable_kuros.direction.next_y = Direction.up;

        else if (Keyboard.GetState().IsKeyDown(Keys.S))
        level_alpha.playable_kuros.direction.next_y = Direction.down;
    
        if (Keyboard.GetState().IsKeyDown(Keys.I)) {
            level_alpha.playable_kuros.health = 10;
            
        level_alpha.playable_kuros.state = _dolphin_status.enabled; }

        if (Keyboard.GetState().IsKeyDown(Keys.J)) {

            if (level_alpha.playable_kuros.state != _dolphin_status.disabled) {
            if ((level_alpha.playable_kuros.state & _dolphin_status.charge) != _dolphin_status.charge) {
                if ((level_alpha.playable_kuros.state & _dolphin_status.jump) != _dolphin_status.jump)
                    level_alpha.playable_kuros.state = _dolphin_status.charge;
                else
                {
                    if ((level_alpha.playable_kuros.status & _dolphin_status.wallop) == _dolphin_status.beached)
                        if ((level_alpha.playable_kuros.status & _dolphin_status.flop) != _dolphin_status.flop)
                        {
                            level_alpha.playable_kuros.status |= _dolphin_status.flop;


                            level_alpha.playable_kuros.physics.velocity_y = -2;
                            level_alpha.playable_kuros.physics.terminal_y = 2;
                            level_alpha.playable_kuros.physics.accelerate_y = 0.05;
                        }
                }
            
            }}
        
        }

            level_alpha.process();

            Render();

            boundary_manager.reset();
            sprite_manager.reset();

    base.Update(gameTime); }

    protected void Render() {

        render_cycle++;
        if ((render_cycle & 0x03) != 0) return;

        display_manager.begin();

            parallax.draw();
            nametable.draw();
            sprite_manager.draw();

        display_manager.end();

    return; }

    protected override void Draw(GameTime gameTime) {
        display_manager.draw();
    base.Draw(gameTime); }

};}
