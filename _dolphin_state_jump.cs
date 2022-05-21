using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace agartha {

public class _dolphin_state_jump {

    public _dolphin_interface di;

    public void get_sequence() {

        di.sequence.set_action(_dolphin_action.jump);
        di.physics.terminal_y = 2.5;
        di.physics.accelerate_y = 0.06;

        di.direction.current = Direction.down;
        di.state = _dolphin_status.jump_wait_sequence;

    return; }

    public void update_velocity() {

        switch (di.direction.next_x) {

        case Direction.left: 
            di.physics.terminal_x = -2;
            di.physics.accelerate_x = -0.01;
        break;

        case Direction.right: 
            di.physics.terminal_x = 2;
            di.physics.accelerate_x = 0.01;
        break; }

    return; }

    public void process() {

        switch (di.state) {

        case _dolphin_status.jump: 
            get_sequence();
        break;

        case _dolphin_status.jump_wait_sequence:
            if (di.sequence.complete == true) {
                di.state = _dolphin_status.jump_wait_boundary;
            di.dolphin_state_default.get_default_sequence(); }
        break;

        case _dolphin_status.jump_clear_boundary:
            di.state = _dolphin_status.jump_deconstructor;
        break;

        case _dolphin_status.jump_deconstructor:
            di.state = _dolphin_status.enabled;
            di.status&= ~_dolphin_status.wallop;
            di.direction.invalidate();
        break; }

        update_velocity();

    return; }
}}
