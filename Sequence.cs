using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

    public class _clip {

        public int delay, total;
        public int[] cell;

        public void add(params int[] data) {
            cell = data;
            total = data.Length;
        return; }
    }

    public class Sequence {

        public _clip[] clip;

        public int action;
 
        public int index, repeat;
        public int cycle;

        public bool complete;

        public Sequence() {

            clip = null;
            action = 0;
            
            index = 0;
            repeat = 0;
            cycle = 0;

            complete = false;

        return; }

        public void set_action(int action) {

            if (this.action == action)
                return;

            cycle = 0;
            index = 0;
            repeat = 0;
            
            complete = false;
            this.action = action;

        return; }

        public void next() {

            cycle = 0;
            index++;

            if (index >= clip[action].total) {
                index = 0;
            repeat++; }

        return; }

        public void update() {

            if (cycle < clip[action].delay) {
                cycle++;

            if (index >= clip[action].total-1)
                complete = true;

            return; }

            next();

        return; }
    }
}
