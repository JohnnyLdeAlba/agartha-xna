using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

public class ProjectileSplash : Sequence {

    Core core;

    int state;
    int x, y;

    public void initialize(Core core) {

        this.core = core;

        clip = new _clip[1];
        clip[0] = new _clip();

        clip[0].delay = 60;
        clip[0].add(69, 70, 71);

        set_action(0);

    return; }

    public void create(double x, double y) {
        state = 1; repeat = 0; index = 0;
        this.x = (int)x; this.y = (int)y;
    return; }

    public void process() { 

        if (state == 0) return;
        
        update();

        int x = core.viewport.translate_x(this.x);
        int y = core.viewport.translate_y(this.y);

        core.sprite_manager.add(clip[0].cell[index], x, y);
        if (repeat > 0) state = 0;
    return; }
}}
