using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace agartha {

    public class PlayableKuros : _dolphin_interface {

        public Viewport viewport;
        public SpriteManager sprite_manager;
        public ProjectileSplash projectile_splash;

        public int breath_cycle, breath_delay;

        public void reset_air() {
            air = 8;
            status &= ~_dolphin_status.breath;
        return; }

        public void decrement_health() {

            if (state == _dolphin_status.disabled)
                return;

            if ((status & _dolphin_status.stunned) == _dolphin_status.stunned)
                return;

            if (health > 0) health--;

            if (health == 0) {
                status = _dolphin_status.disabled;
            state = _dolphin_status.disabled; }

        return; }

        public void decrement_air() {

            if (state == _dolphin_status.disabled)
                return;

            if ((status & _dolphin_status.breath) == _dolphin_status.breath) {
                decrement_health();
            return; }

            air--;
            if (air == 1) status|= _dolphin_status.breath;

        return; }


        public void update_air() {

            if (breath_cycle < breath_delay)
                { breath_cycle++; return; }
            
            decrement_air();
            breath_cycle = 0;

        return; }

        public void set_position(double x, double y) {
            physics.set_position(x, y);
        return; }

        public void create_sequence() {

            _clip[] clip;

            sequence.clip = new _clip[19];
            clip = sequence.clip;

            for (int count = 0; count < clip.Length; count++)
                clip[count] = new _clip();

            clip[0].delay = 80;
            clip[0].add(15, 16, 17, 18);

            clip[1].delay = 80;
            clip[1].add(21, 22, 23, 24);

            clip[2].delay = 80;
            clip[2].add(1, 2, 3, 4, 5);

            clip[3].delay = 80;
            clip[3].add(8, 9, 10, 11, 12);

            clip[4].delay = 40;
            clip[4].add(27, 28, 29, 2);

            clip[5].delay = 40;
            clip[5].add(30, 31, 32, 9);

            clip[6].delay = 40;
            clip[6].add(33, 34, 35, 36);

            clip[7].delay = 40;
            clip[7].add(37, 38, 39, 40);

            clip[8].delay = 150;
            clip[8].add(2, 2);

            clip[9].delay = 100;
            clip[9].add(9, 9);

            clip[10].delay = 100;
            clip[10].add(15, 15);

            clip[11].delay = 100;
            clip[11].add(21, 21);

            clip[12].delay = 50;
            clip[12].add(41, 42, 43, 44, 45, 46, 47, 48);

            clip[13].delay = 200;
            clip[13].add(6, 6, 6, 6, 6, 7, 6, 6, 7);

            clip[14].delay = 200;
            clip[14].add(13, 13, 13, 13, 13, 14, 13, 13, 14);

            clip[15].delay = 200;
            clip[15].add(19, 19, 19, 19, 19, 20, 19, 19, 20);

            clip[16].delay = 200;
            clip[16].add(25, 25, 25, 25, 25, 25, 26, 26, 25);

            clip[17].delay = 0;
            clip[17].add(4);

            clip[18].delay = 0;
            clip[18].add(11);

            sequence.set_action(_dolphin_action.right_idle);

        return; }

        public void get_handler() {

            _dolphin_interface di = this as _dolphin_interface;

            dolphin_hud = new _dolphin_hud();

            dolphin_state_default = new _dolphin_state_default();
            dolphin_state_charge = new _dolphin_state_charge();
            dolphin_state_jump = new _dolphin_state_jump();

            dolphin_status_stunned = new _dolphin_status_stunned();

            dolphin_hud.initialize(di);

            dolphin_state_default.di = di;
            dolphin_state_charge.di = di;
            dolphin_state_jump.di = di;

            dolphin_status_stunned.initialize(di);

        return; }

        public void initialize(Core core) {

            this.core = core;

            viewport = core.viewport;
            sprite_manager = core.sprite_manager;

            physics = new Physics();
            direction = new Direction();
            sequence = new Sequence();

            physics.width = 24;
            physics.height = 24;

            get_handler();
            create_sequence();

            state = _dolphin_status.enabled;

            breath_delay = 3000;

            reset_air();
            health = 8;
            
        return; }

        public void update_sprite() {

            sequence.update();

            if (dolphin_status_stunned.check() == false)
                return;

            int pattern_id = sequence.clip[sequence.action].cell[sequence.index];

            int x = viewport.translate_x((int)physics.x);
            int y = viewport.translate_y((int)physics.y);
            
            sprite_manager.add(pattern_id, x, y);

        return; }

        public void hud() {

            dolphin_hud.render();

        return; }

        public void update_next_position() {
            direction.update();
            physics.get_next_position();
        return; }

        public void update_position() {

            if (direction.next_x != Direction.invalid_x)
                physics.x = physics.next_position_x;
            if (direction.next_y != Direction.invalid_y)
                physics.y = physics.next_position_y;

            if (physics.x < physics.previous_position_x)
                direction.current_x = Direction.left;
            else if (physics.x > physics.previous_position_x)
                direction.current_x = Direction.right;

            if (physics.y < physics.previous_position_y)
                direction.current_y = Direction.up;
            else if (physics.y > physics.previous_position_y)
                direction.current_y = Direction.down;

            physics.previous_position_x = physics.x;
            physics.previous_position_y = physics.y;

        return; }

        public void update_viewport() {

            switch (direction.current_x) {

            case Direction.left:
                viewport.update_x(Direction.left,
                    (int)physics.x+16);
            break;

            case Direction.right:
                viewport.update_x(Direction.right,
                    (int)physics.x);
            break; }

            switch (direction.current_y) {

            case Direction.up:
                viewport.update_y(Direction.up,
                    (int)physics.y+16);
            break;

            case Direction.down:
                viewport.update_y(Direction.down,
                    (int)physics.y);
            break; }

        return; }

        public void recoil(int next_direction) {

            switch (next_direction) {

            case Direction.left: 
                physics.velocity_x = -2;
                physics.terminal_x = 0;
                physics.accelerate_x = 0.04;
            break;

            case Direction.right: 
                physics.velocity_x = 2;
                physics.terminal_x = 0;
                physics.accelerate_x = -0.04;
            break;

            case Direction.up: 
                physics.velocity_y = -2;
                physics.terminal_y = 0;
                physics.accelerate_y = 0.04;
            break;

            case Direction.down: 
                physics.velocity_y = 2;
                physics.terminal_y = 0;
                physics.accelerate_y = -0.04;
            break; }

        return; }

        public void segment_state_jump(_boundary_interface boundary) {

            if ((status & _dolphin_status.wallop) == _dolphin_status.beached) {

                if ((status & _dolphin_status.flop) == _dolphin_status.flop)
                    status &= ~_dolphin_status.flop;

                if (direction.current_x == Direction.left) {
                    sequence.set_action(_dolphin_action.left_beached);
                return; }

                sequence.set_action(_dolphin_action.right_beached);

            return; }

            if ((status & _dolphin_status.wallop) != _dolphin_status.disabled)
                return;

            physics.velocity_y = 0;
            
            status|= _dolphin_status.beached;
            
        return; }

        public void boundary_state_segment(_boundary_interface boundary) {

            if (physics.boundary_x(boundary) == true)
                direction.next_x = Direction.invalid_x;

            if (physics.boundary_y(boundary) == true) {

                if ((state & _dolphin_status.jump) == _dolphin_status.jump)
                    segment_state_jump(boundary);

             direction.next_y = Direction.invalid_y; }

        return; }

        public void boundary_state_wall(_boundary_interface boundary)
        {

            if (physics.boundary_x(boundary) == true)
                direction.next_x = Direction.invalid_x;

            if (physics.boundary_y(boundary) == true)
            {

                if ((state & _dolphin_status.jump) == _dolphin_status.jump) {

                    state = _dolphin_status.jump_wait_boundary;

                    physics.velocity_y = 0;

                    direction.current_y = Direction.down;
                    dolphin_state_default.get_default_sequence();
                }

                direction.next_y = Direction.invalid_y;
            }

            return;
        }

        public void boundary_state_jump(_boundary_interface boundary) {

            switch (state) {

            case _dolphin_status.jump_wait_boundary:

                if ((physics.x+physics.width > boundary.x)
                    && (physics.x < boundary.x+boundary.width))

                if (physics.y > boundary.y+boundary.height) {
                    state = _dolphin_status.jump_clear_boundary;
                projectile_splash.create(physics.x+8, physics.y-2); }

            break;

            case _dolphin_status.charge_deconstructor:

                if (direction.current == Direction.up) {
                    if (physics.boundary_y(boundary) == true) {
                        reset_air();
                state = _dolphin_status.jump; }}

                else goto default;

            break;

            default:

                if ((state & _dolphin_status.jump) == _dolphin_status.jump)
                    return;

                if (physics.boundary_x(boundary) == true) {
                    reset_air();
                direction.next_x = Direction.invalid_x; }
                
                if (physics.boundary_y(boundary) == true) {
                    reset_air();
                direction.next_y = Direction.invalid_y; }

            break;
            
        } return; }

        public void boundary_state_damage(_boundary_interface boundary) {
        
            if ((status & _dolphin_status.stunned) == _dolphin_status.stunned) return;

            if (physics.boundary(boundary) == false) return;

            if ((state & _dolphin_status.jump) == _dolphin_status.jump) {
                decrement_health();
                status|= _dolphin_status.stunned;
            return; }

            if ((status & _dolphin_status.recoil) == _dolphin_status.recoil)
                return;

            direction.next_x = Direction.invalid_x;
            direction.next_y = Direction.invalid_y;

            switch (direction.current) {

            case Direction.left:
                recoil(Direction.right);
            break;
            
            case Direction.right:
                recoil(Direction.left);
            break;

            case Direction.up:
                recoil(Direction.down);
            break;

            case Direction.down:
                recoil(Direction.up);
            break; }

            if ((state & _dolphin_status.charge) == _dolphin_status.charge) {
                status|= _dolphin_status.recoil;
            return; }

            decrement_health();
            status|= _dolphin_status.stunned;

            dolphin_state_default.get_default_sequence();

        return; }

        public void compare(_boundary_interface boundary) {

            if (state == _dolphin_status.disabled)
                return;

            switch (boundary.state) {

            case _boundary_status.segment:
                boundary_state_segment(boundary);
            break;

            case _boundary_status.wall:
                boundary_state_wall(boundary);
            break;

            case _boundary_status.jump:
                boundary_state_jump(boundary);
            break;
            
            case _boundary_status.damage:
                boundary_state_damage(boundary);
            break;

        } return; }

        public void process() {

            if (state == _dolphin_status.disabled)
                return;

            var current_state = state & _dolphin_status.identity;
            direction.next = (direction.next_x | direction.next_y);

            switch (current_state) {

            case _dolphin_status.charge:
                dolphin_state_charge.process();
            break;

            case _dolphin_status.jump:
                dolphin_state_jump.process();
            break;

            default: dolphin_state_default.process();
                break; }

            update_air();
            update_next_position();

        return; }

        public void update() {

            if (state == _dolphin_status.disabled)
                return;

            update_position();
            update_viewport();
            update_sprite();

        return; }
    }
}
