using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace agartha {

public class Viewport {

    public Core core;
    public NPCManager npc_manager;

    public Matrix matrix;
    public NameTable nametable;
    public Parallax parallax;

    public int direction, x, y;
    public int previous_x, previous_y;

    public void initialize(Core core) {

        this.core = core;
        
        matrix  = new Matrix();

        npc_manager = core.npc_manager;
        nametable = core.nametable;
        parallax = core.parallax;

    return; }

    public void set_position(int x, int y) {

        this.x = x; this.y = y;
        previous_x = x; previous_y = y;

        parallax.set_position((double)x, (double)y);

    return; }

    public void set_vector(int[][] vector) {

        matrix.set_vector(vector);

    return; }

    public void set_dimensions(int w, int h) {

        matrix.set_dimensions(w, h);

    return; }

    public void increment_x(int quantity) {

        int row = x >> 8;

        if (row >= (matrix.width-1)) {
            x = row << 8;
        return; }

        x+= quantity;
        parallax.increment_x((double)quantity);

        if ((x-previous_x) >= 4) {
            previous_x = x;
        direction|= Direction.right; }

    return; }

    public void decrement_x(int quantity) {

        if (x <= 0) { x = 0; return; }

        x+= quantity;
        parallax.decrement_x((double)quantity);

        if ((x-previous_x) <= -4) {
            previous_x = x;
        direction|= Direction.left; }

    return; }

    public void increment_y(int quantity) {

        int column = y >> 8;
        if (column >= (matrix.height-1)) {
            y = column << 8;
        return; }

        y+= quantity;
        parallax.increment_y((double)quantity);

        if ((y-previous_y) >= 4) {
            previous_y = y;
        direction|= Direction.down; }

    return; }

    public void decrement_y(int quantity) {

        if (y <= 0) { y = 0; return; }

        y+= quantity;
        parallax.decrement_y((double)quantity);

        if ((y-previous_y) <= -4) {
            previous_y = y;
        direction|= Direction.up; }

    return; }

    public void validate_all() {

        for (int count  = 0; count < 16; count++) {

            matrix.set_position(x+(count*16), y);
            matrix.get_vertical();
        nametable.set_vertical(matrix.vertical); }

        parallax.validate_all();

    return; }

    public void validate_x() {

        if ((direction & Direction.identity_x) == 0)
            return;

        if ((direction & Direction.left) != 0)
            matrix.set_position(x, y);

        else matrix.set_position(x+240, y);

        direction&= Direction.opposite_x;

        matrix.get_vertical();
        nametable.set_vertical(matrix.vertical);

    return; }

    public void validate_y() {

        if ((direction & Direction.identity_y) == 0)
            return;

        if ((direction & Direction.up) != 0)
            matrix.set_position(x, y);

        else matrix.set_position(x, y+240);

        direction&= Direction.opposite_y;

        matrix.get_horizontal();
        nametable.set_horizontal(matrix.horizontal);

    return; }

    public void update_x(int direction, int x) {

        int center_x = this.x+128;

        if ((direction == Direction.left) && (x <= center_x))
            decrement_x(x-center_x);
        else if ((direction == Direction.right) && (x >= center_x))
            increment_x(x-center_x);

    return; }

    public void update_y(int direction, int y) {

        int center_y = this.y+128;

        if ((direction == Direction.up) && (y <= center_y))
            decrement_y(y-center_y); 
        else if ((direction == Direction.down) && (y >= center_y))
            increment_y(y-center_y);

    return; }

    public void update() {

        if (direction != Direction.idle) { validate_x(); validate_y(); }

        npc_manager.set_position(x-128, y-128);
        nametable.set_position(x, y);

        parallax.update();

    return; }

    public int translate_x(int x) { return (x-this.x-16); }
    public int translate_y(int y) { return (y-this.y-16); }
}}
