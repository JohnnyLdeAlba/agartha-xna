using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace agartha
{
    public class Physics {

        public double x, y;
        public int width, height;

        public int position_cycle;
        public int position_delay;

        public double previous_position_x, previous_position_y;
        public double next_position_x, next_position_y;

        public double velocity_x, velocity_y;
        public double terminal_x, terminal_y;
        public double accelerate_x, accelerate_y;

        public Physics() {

            x = 0; y = 0;

            position_cycle = 0;
            position_delay = 4;

            next_position_x = 0; next_position_y = 0;

            velocity_x = 0; velocity_y = 0;
            terminal_x = 0; terminal_y = 0;
            accelerate_x = 0; accelerate_y = 0;

        return; }

        public void set_position(double x, double y) {

            this.x = x; this.y = y;
            next_position_x = x; next_position_y = y;

        return; }

        public void get_position_x() {

            next_position_x = x;

            if (accelerate_x > 0.0) {

                if (velocity_x < terminal_x)
                    velocity_x+= accelerate_x;

            else velocity_x = terminal_x; }
            
            else if (accelerate_x < -0.0) {

                if (velocity_x > terminal_x)
                    velocity_x+= accelerate_x;

            else velocity_x = terminal_x; }

            next_position_x+= velocity_x;

        return; }

        public void get_position_y() {

            next_position_y = y;

            if (accelerate_y > 0.0) {

                if (velocity_y < terminal_y)
                    velocity_y+= accelerate_y;
            
            else velocity_y = terminal_y; }
            
            else if (accelerate_y < -0.0) {

                if (velocity_y > terminal_y)
                    velocity_y+= accelerate_y;

            else velocity_y = terminal_y; }

            next_position_y+= velocity_y;

        return; }

        public void get_next_position() {

            if (position_cycle < position_delay) {
                position_cycle++;
            return; }

            position_cycle = 0;

            get_position_x();
            get_position_y();

        return; }

        public bool boundary(_boundary_interface boundary) {

            if ((next_position_x+width < boundary.x)
                || (next_position_x > boundary.x+boundary.width))
            return false;

            else if ((next_position_y+height < boundary.y)
                || (next_position_y > boundary.y+boundary.height))
            return false;

        return true; }

        public bool boundary_x(_boundary_interface boundary) {

            if ((next_position_x+width < boundary.x)
                || (next_position_x > boundary.x+boundary.width))
            return false;

            else if ((y+height < boundary.y)
                || (y > boundary.y+boundary.height))
            return false;

        return true; }

        public bool boundary_y(_boundary_interface boundary) {

            if ((x+width < boundary.x)
                || (x > boundary.x+boundary.width))
            return false;

            else if ((next_position_y+height < boundary.y)
                || (next_position_y > boundary.y+boundary.height))
            return false;

        return true; }

    }
}
