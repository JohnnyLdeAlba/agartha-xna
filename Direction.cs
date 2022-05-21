using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agartha {

public class Direction {

    public const int identity_x = 0x00ff;
    public const int identity_y = 0xff00;

    public const int opposite_x = 0xff00;
    public const int opposite_y = 0x00ff;

    public const int invalid_x = 0x00ee;
    public const int invalid_y = 0xee00;

    public const int idle = 0x0000;


    public const int left = 0x000f;
    public const int right = 0x00f0;
    public const int up = 0x0f00;
    public const int down = 0xf000;

    public const int upleft = 0x0f0f;
    public const int upright = 0x0ff0;
    public const int downleft = 0xf00f;
    public const int downright = 0xf0f0;

    public int current;
    public int current_x;
    public int current_y;

    public int next;
    public int next_x;
    public int next_y;

    public int previous;
    public int previous_x;
    public int previous_y;

    public void invalidate() {

        next_x = invalid_x;
        next_y = invalid_y;

        previous_x = invalid_x;
        previous_y = invalid_y;

        next = next_x | next_y;
        previous = previous_x | previous_y;

    return; }

    public void update() {

        next = (next_x | next_y);

        if (next == previous) return;

        previous_x = next_x;
        previous_y = next_y;

        previous = (previous_x | previous_y);

    return; }

}}
