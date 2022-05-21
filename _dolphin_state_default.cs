using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

public class _dolphin_state_default {

    public _dolphin_interface di;

    public void direction_default_x() {

        switch (di.direction.current_x) {

        case Direction.left:  

            di.physics.terminal_x = 0;
            di.physics.accelerate_x = 0.04;

        break; 
    
        case Direction.right:  

            di.physics.terminal_x = 0;
            di.physics.accelerate_x = -0.04;

        break; }

    return; }

    public void direction_default_y() {

        switch (di.direction.current_y) {

        case Direction.up:  

            di.physics.terminal_y = 0;
            di.physics.accelerate_y = 0.04;

        break; 
    
        case Direction.down:  

            di.physics.terminal_y = 0;
            di.physics.accelerate_y = -0.04;

        break; }

    return; }

    public void get_direction_x() {

        if (di.direction.next_x == di.direction.previous_x)
            return;

        switch (di.direction.next_x) {

        case Direction.left:

            di.physics.terminal_x = -2;
            di.physics.accelerate_x = -0.1;

        break;

        case Direction.right:

            di.physics.terminal_x = 2;
            di.physics.accelerate_x = 0.1;

        break;

        default: direction_default_x();
            break; }

    return; }

    public void get_direction_y() {

        if (di.direction.next_y == di.direction.previous_y)
            return;

        switch (di.direction.next_y) {

        case Direction.up:

            di.physics.terminal_y = -2;
            di.physics.accelerate_y = -0.1;

        break;

        case Direction.down:

            di.physics.terminal_y = 2;
            di.physics.accelerate_y = 0.1;

        break;
    
        default: direction_default_y();
            break; }
        
     return; }

     public void update_direction_position() {
    
        get_direction_x();
        get_direction_y();

    return; }

    public void get_default_sequence() {

        switch (di.direction.current) {

        case Direction.left:
            di.sequence.set_action(_dolphin_action.left_idle);
        break;

        case Direction.right:
            di.sequence.set_action(_dolphin_action.right_idle);
        break;

        case Direction.up:
                di.sequence.set_action(_dolphin_action.up_idle);
        break;

        case Direction.down:
                di.sequence.set_action(_dolphin_action.down_idle);
        break; }

    return; }

    public void update_direction_sequence() {

        if (di.direction.next == di.direction.previous)
            return;

        if (di.direction.next == Direction.idle) {
            get_default_sequence();
        return; }

        switch (di.direction.next) {

        case Direction.left:
                di.sequence.set_action(_dolphin_action.left);
        break;

        case Direction.right:
                di.sequence.set_action(_dolphin_action.right);
        break;

        case Direction.up: case Direction.upleft:
            case Direction.upright:
                di.sequence.set_action(_dolphin_action.up);
        break;

        case Direction.down: case Direction.downleft:
            case Direction.downright:
                di.sequence.set_action(_dolphin_action.down);
        break; }

    return; }

    public void process() {

        update_direction_position();
        update_direction_sequence();

        if ((di.direction.next_y == Direction.idle)
            && (di.direction.next_x != Direction.idle))
                di.direction.current = di.direction.next_x;

        else if (di.direction.next_y != Direction.idle)
            di.direction.current = di.direction.next_y;

    return; }
}}
