using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

public class _dolphin_state_charge {

    public _dolphin_interface di;
    public int cycle;

    public void update_boundary() {

        _boundary_interface boundary = new _boundary_interface();

        boundary.set_position((int)di.physics.x, (int)di.physics.y);
        boundary.set_dimensions(di.physics.width, di.physics.height);

        boundary.state = _boundary_status.attack;
        di.core.boundary_manager.add(boundary);

    return; }

    public void get_sequence() {

        switch (di.direction.current) {

        case Direction.left: 
            di.sequence.set_action(_dolphin_action.left_charge);
        break;

        case Direction.right: 
            di.sequence.set_action(_dolphin_action.right_charge);
        break;

        case Direction.up:
            di.sequence.set_action(_dolphin_action.up_charge);
        break;

        case Direction.down:
            di.sequence.set_action(_dolphin_action.down_charge);
        break; }

        cycle = 0;
        di.state = _dolphin_status.charge_wait_sequence;

    return; }

    public void get_default_sequence() {

        switch (di.direction.current) {

        case Direction.left:
            di.sequence.set_action(_dolphin_action.left_charge_idle);
        break;

        case Direction.right:
            di.sequence.set_action(_dolphin_action.right_charge_idle);
        break;

        case Direction.up:
                di.sequence.set_action(_dolphin_action.up_charge_idle);
        break;

        case Direction.down:
                di.sequence.set_action(_dolphin_action.down_charge_idle);
        break; }

    return; }

    public void get_velocity() {

        switch (di.direction.current) {

        case Direction.left: 
            di.physics.velocity_x = -4;
            di.physics.terminal_x = 0;
            di.physics.accelerate_x = 0.04;
        break;

        case Direction.right: 
            di.physics.velocity_x = 4;
            di.physics.terminal_x = 0;
            di.physics.accelerate_x = -0.04;
        break;

        case Direction.up: 
            di.physics.velocity_y = -4;
            di.physics.terminal_y = 0;
            di.physics.accelerate_y = 0.04;
        break;

        case Direction.down: 
            di.physics.velocity_y = 4;
            di.physics.terminal_y = 0;
            di.physics.accelerate_y = -0.04;
        break; }

        get_default_sequence();
        di.state = _dolphin_status.charge_deconstructor;

    return; }


    public void update_velocity() {

        if ((di.direction.current & Direction.identity_x) == 0) {

        switch (di.direction.next_x) {

        case Direction.left: 
            di.physics.terminal_x = -2;
            di.physics.accelerate_x = -0.01;
        break;

        case Direction.right: 
            di.physics.terminal_x = 2;
            di.physics.accelerate_x = 0.01;
        break; }}

        else if ((di.direction.current & Direction.identity_y) == 0) {

        switch (di.direction.next_y) {

        case Direction.up: 
            di.physics.terminal_y = -2;
            di.physics.accelerate_y = -0.01;
        break;

        case Direction.down: 
            di.physics.terminal_y = 2;
            di.physics.accelerate_y = 0.01;
        break; }}

    return; }

    public void process() {

        switch (di.state) {

        case _dolphin_status.charge: 
            get_sequence();
        break;

        case _dolphin_status.charge_wait_sequence:
            if (di.sequence.complete == true)
                di.state = _dolphin_status.charge_update_velocity;
        break;

        case _dolphin_status.charge_update_velocity:
            get_velocity();
        break;

        case _dolphin_status.charge_deconstructor:

            if (di.sequence.complete == true) {

                di.state = _dolphin_status.enabled;
                di.status&= ~_dolphin_status.recoil;
                di.direction.invalidate();

            di.dolphin_state_default.get_default_sequence(); }

        break; }

        update_boundary();
        update_velocity();

    return; }
}}
