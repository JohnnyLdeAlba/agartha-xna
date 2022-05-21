using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

public class ForegroundManager {

    public Core core;

    public int index, total;
    public _npc_interface[] table;

    public void reset() {

        index = 0;

        for (int count = 0; count < total; count++) {
            table[count].state = 0;
            table[count].set_position(0, 0);
        table[count].set_dimensions(0, 0); }

    return; }

    public void initialize(Core core) {

        this.core = core;

        index = 0; total = 32;
        table = new _npc_interface[total];

        for (int count = 0; count < total; count++)
            table[count] = new _npc_interface();

        reset();

    return; }

    public void generate_next_id() {
            
        if (index >= total) return;
        if (table[index].state == 0) return;

        index++;

    return; }

    public void add(_npc_interface npc) {

        table[index].copy(npc);
        generate_next_id();

    return; }

    public void update() {

        int x, y;

        for (int count = 0; count < index; count++) {
            if (table[count].state == 0) return;

            x = core.viewport.translate_x((int)table[count].x);
            y = core.viewport.translate_y((int)table[count].y);
        
        core.sprite_manager.add(table[count].parameter, x, y); }

    return; }
}}
