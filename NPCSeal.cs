using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace agartha {
public class NPCSeal {

    public Core core;

    public int state;
    public Physics physics;
    public Sequence sequence;

    public void initialize(Core core) {

        this.core = core;

        physics = new Physics();
        sequence = new Sequence();

        physics.set_position(0, 0);

        physics.width = 32;
        physics.height = 32;

        sequence.clip = new _clip[2];
        
        sequence.clip[0] = new _clip();

        sequence.clip[0].delay = 1000;
        sequence.clip[0].add(94, 94);

        sequence.clip[1] = new _clip();

        sequence.clip[1].delay = 100;
        sequence.clip[1].add(95, 96, 97, 96, 97, 96, 97, 95, 95);
        
        sequence.set_action(0);

    return; }

    public void set_component(_npc_interface npc) {

        state = _npc_status.enabled;
        physics.set_position(npc.x, npc.y);

    return; }

    public _boundary_interface boundary() {

        _boundary_interface boundary = new _boundary_interface();

        boundary.set_position((int)physics.x, (int)physics.y);
        boundary.set_dimensions(physics.width, physics.height);

    return boundary; }

    public void process() {

            if (sequence.complete == true) {
                sequence.set_action(((sequence.action ^ 0x000001) & 0x000001));
            }

            sequence.update();

            int pattern_id = sequence.clip[sequence.action].cell[sequence.index];

            int x = core.viewport.translate_x((int)physics.x);
            int y = core.viewport.translate_y((int)physics.y);
            
            _boundary_interface boundary = this.boundary();
            boundary.state = _boundary_status.damage;

            core.sprite_manager.add(pattern_id, x, y);

            core.boundary_manager.add(boundary);

            physics.get_next_position();
            physics.set_position(physics.next_position_x, physics.next_position_y);

    return; }
}}
