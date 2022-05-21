using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace agartha {

public class _boundary_status {

    public const int disabled = 0x000000;
    public const int enabled = 0xf00000;
    public const int segment = 0xf00001;
    public const int jump = 0xf00002;
    public const int attack = 0xf00003;
    public const int damage = 0xf00004;
    public const int wall = 0xf00005;
}

public class _boundary_interface {

    public int state;

    public int x, y;
    public int width, height;

    public void set_position(int x, int y) {
        this.x = x; this.y = y; 
    return; }

    public void set_dimensions(int w, int h) {
        width = w; height = h;
    return; }

    public void copy(_boundary_interface source) {

        state = source.state;

        set_position(source.x, source.y);
        set_dimensions(source.width, source.height);

    return; }
}

public class BoundaryManager {

    public Core core;

    public int index, total;
    public _boundary_interface[] table;

    public void reset() {

        index = 0;

        for (int count = 0; count < 64; count++) {
            table[count].state = 0;
            table[count].set_position(0, 0);
        table[count].set_dimensions(0, 0); }

    return; }

    public void initialize(Core core) {

        this.core = core;

        index = 0;
        table = new _boundary_interface[64];

        for (int count = 0; count < 64; count++)
            table[count] = new _boundary_interface();

        reset();

    return; }

    public void generate_next_id() {
            
        if (index >= 64) return;
        if (table[index].state == 0) return;

        index++;

    return; }

    public void set_position(int x, int y) {

        table[index].set_position(x, y);

    return; }

    public void set_dimensions(int w, int h) {

        table[index].set_dimensions(w, h);

    return; }

    public void add(int state) {

        table[index].state = state;
        generate_next_id();

    return; }

    public void add(_boundary_interface boundary) {

        table[index].copy(boundary);
        generate_next_id();

    return; }

}}