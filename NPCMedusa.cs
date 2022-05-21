using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

public class _medusa_status_stunned {

    NPCMedusa di;

    int cycle, delay;
    int toggle_cycle, toggle_delay, toggle;

    public void initialize(NPCMedusa di) {

        this.di = di;

        delay = 1000;
        toggle_delay = 100;

    return; }

    public void update() {

            if (cycle < delay) { cycle++; return; }
            
            cycle = 0;
            di.status &= ~_npc_status.stunned;
            
    return; }

    public bool check() {

        if ((di.status & _npc_status.stunned) != _npc_status.stunned)
            return true;

        update();

        if (toggle_cycle >= toggle_delay) {
            toggle_cycle = 0;
            toggle ^= 1;
        return true; }
            
        toggle_cycle++;
        
        if (toggle == 1) return true;

    return false; }
}

public class NPCMedusa {

    public Core core;

    public int state;
    public int status;

    public Physics physics;
    public Sequence sequence;

    public int health;

    public _medusa_status_stunned medusa_status_stunned;

    public void initialize(Core core) {

        this.core = core;

        physics = new Physics();
        sequence = new Sequence();

        health = 3;

        physics.set_position(0, 0);

        physics.terminal_y = 1;
        physics.accelerate_y = 0.1;

        physics.width = 32;
        physics.height = 32;

        sequence.clip = new _clip[1];
        sequence.clip[0] = new _clip();

        sequence.clip[0].delay = 150;
        sequence.clip[0].add(73, 74, 75, 74, 73, 76, 77, 76);
        
        sequence.set_action(0);

        medusa_status_stunned = new _medusa_status_stunned();
        medusa_status_stunned.initialize(this);

    return; }

    public _boundary_interface boundary() {

        _boundary_interface boundary = new _boundary_interface();

        boundary.set_position((int)physics.x, (int)physics.y);
        boundary.set_dimensions(physics.width, physics.height);

    return boundary; }

    public void decrement_health() {

        if (state == _npc_status.disabled)
            return;

        if ((status & _npc_status.stunned) == _npc_status.stunned)
            return;

        if (health > 0) health--;

        if (health == 0) {
            status = _npc_status.disabled;
        state = _npc_status.expired; }

    return; }

    public void set_component(_npc_interface npc) {

        state = _npc_status.enabled;
        status = _npc_status.disabled;

        health = 3;
        physics.set_position(npc.x, npc.y);

    return; }

    public void compare_boundary() {

        _boundary_interface boundary;

        for (int count = 0; count <= core.boundary_manager.index; count++) {
            if (core.boundary_manager.table[count].state == 0)
                return;

        boundary = core.boundary_manager.table[count];

        switch (boundary.state) {

        case _boundary_status.attack: {
                
            if (physics.boundary(boundary) == false)
                break;

            if ((status & _npc_status.stunned) == _npc_status.stunned)
                break;

            decrement_health();
            status|= _npc_status.stunned;

        break; }}}

    return; }

    public void update_boundary() {

        _boundary_interface boundary = this.boundary();

        boundary.state = _boundary_status.damage;
        core.boundary_manager.add(boundary);

    return; }

    public void update_position() {

        if (physics.velocity_y >= 0.1) {
            physics.terminal_y = -1;
        physics.accelerate_y = -0.004; }
            
        else if (physics.velocity_y <= -0.1) {
            physics.terminal_y = 1;
        physics.accelerate_y = 0.004; }

        physics.get_next_position();
        physics.set_position(physics.next_position_x,
            physics.next_position_y);

    return; }

    public void update_sprite() {

        sequence.update();

        if (medusa_status_stunned.check() == false)
            return;

        int pattern_id = sequence.clip[sequence.action].cell[sequence.index];

        int x = core.viewport.translate_x((int)physics.x);
        int y = core.viewport.translate_y((int)physics.y);

        core.sprite_manager.add(72, x, y);
        core.sprite_manager.add(pattern_id, x, y + 16);

    return; }

    public void process() {

        if (state == _npc_status.expired)
            return;

        compare_boundary();

        update_position();
        update_boundary();
        update_sprite();

    return; }
}}
