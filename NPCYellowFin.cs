using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {
public class NPCYellowFin {

    public Core core;

    public int state;
    public Physics physics;
    public Sequence[] sequence;

    public void initialize(Core core) {

        this.core = core;

        physics = new Physics();
        sequence = new Sequence[2];

        physics.set_position(0, 0);

        physics.width = 64;
        physics.height = 16;

        sequence[0] = new Sequence();
        sequence[0].clip = new _clip[1];
        sequence[0].clip[0] = new _clip();

        sequence[0].clip[0].delay = 100;
        sequence[0].clip[0].add(98, 99);

        sequence[1] = new Sequence();
        sequence[1].clip = new _clip[1];
        sequence[1].clip[0] = new _clip();

        sequence[1].clip[0].delay = 150;
        sequence[1].clip[0].add(100, 101, 102, 101);

        sequence[0].set_action(0);
        sequence[1].set_action(0);

        physics.terminal_x = 0.0;
        physics.accelerate_x = 0.0005;

    return; }

    public void randomize() {
        
        Random random = new Random();

        int value = random.Next(1, 10);
        physics.accelerate_x = ((float)value/10000);

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

            sequence[1].update();

        if (sequence[0].index == 1)
            sequence[0].update();

            int primary_pattern = sequence[0].clip[0].cell[sequence[0].index];
            int secondary_pattern = sequence[1].clip[0].cell[sequence[1].index];

            int x = core.viewport.translate_x((int)physics.x);
            int y = core.viewport.translate_y((int)physics.y);
            
            _boundary_interface boundary = this.boundary();
            boundary.state = _boundary_status.damage;

            core.sprite_manager.add(primary_pattern, x, y);
            core.sprite_manager.add(secondary_pattern, x+32, y);

            core.boundary_manager.add(boundary);

            if (physics.velocity_x >= 0.0) {
                physics.velocity_x = -0.2;
                sequence[0].next(); }

            physics.get_next_position();
            physics.set_position(physics.next_position_x, physics.next_position_y);

    return; }
}}
