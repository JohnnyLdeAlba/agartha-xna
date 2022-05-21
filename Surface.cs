using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

    public class Surface {

        public Core core;
        public Sequence sequence;

        public int state;
        public double x, y;
        public int width;

        public Surface(Core core) {

            this.core = core;

            sequence = new Sequence();
            sequence.clip = new _clip[1];

            sequence.clip[0] = new _clip();
            sequence.clip[0].delay = 100;
            sequence.clip[0].add(54, 55, 56, 57);

            set_position(0, 0);
            set_width(0);

        return; }

        public void set_component(_npc_interface npc) {

            state = _npc_status.enabled;
            set_position(npc.x, npc.y);
            set_width(npc.width);

        return; }

        public _boundary_interface boundary() {

            _boundary_interface boundary = new _boundary_interface();

            boundary.set_position((int)x, (int)y);
            boundary.set_dimensions(width, 1);

        return boundary; }

        public void set_position(double x, double y) {
            this.x = x; this.y = y;
        return; }

        public void set_width(int w) { width = w; return; }

        public void process() {

            core.boundary_manager.set_position((int)x, (int)y);
            core.boundary_manager.set_dimensions(this.width, 1);
            core.boundary_manager.add(_boundary_status.jump);

        return; }

        public void update() {

            int pattern_id;
            int x, y, total;

            sequence.update();

            pattern_id = sequence.clip[0].cell[sequence.index];

            x = core.viewport.translate_x((int)this.x);
            y = core.viewport.translate_y((int)this.y+12);

            total = width/16;

            for (int count = 0; count < total; count++)
                core.sprite_manager.add(pattern_id, x+(count*16), y);

        return; }

}}
