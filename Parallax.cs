using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace agartha {

public class Parallax {

    public Core core;

    public Matrix matrix;
    public NameTable nametable;

    public int direction;
    public double x, y;
    public double previous_x, previous_y;
    public double quotient_x, quotient_y;

    public void initialize(Core core) {

        this.core = core;

        matrix  = new Matrix();
        nametable = new NameTable();

        nametable.initialize(core);

    return; }

    public void set_vector(int[][] vector) {

        matrix.set_vector(vector);

    return; }

    public void set_dimensions(int w, int h) {

        matrix.set_dimensions(w, h);

    return; }

    public void set_quotient(double x, double y) {

        quotient_x = x;
        quotient_y = y;

    return; }

    public void set_position(double x, double y) {

        if (quotient_x != 0)
            this.x = x/quotient_x;
        if (quotient_y != 0)
            this.y = y/quotient_y;

    return; }

    public void increment_x(double quantity) {

        if (quotient_x == 0) return;

        double row = x/256;
        if (row >= (matrix.width-1)) {
            x = row * 256;
        return; }

        x+= quantity/quotient_x;

        if ((x-previous_x) >= 4) {
            previous_x = x;
        direction|= Direction.right; }

    return; }

    public void decrement_x(double quantity) {

        if (quotient_x == 0) return;
        if (x <= 0) { x = 0; return; }

        x+= quantity/quotient_x;

        if ((x-previous_x) <= -4) {
            previous_x = x;
        direction|= Direction.left; }

    return; }

    public void increment_y(double quantity) {

        if (quotient_y == 0) return;
        double column = y/256;

        if (column >= (matrix.height-1)) {
            y = column * 256;
        return; }

        y+= quantity/quotient_y;

        if ((y-previous_y) >= 4) {
            previous_y = y;
        direction|= Direction.down; }

    return; }

    public void decrement_y(double quantity) {

        if (quotient_y == 0) return;
        if (y <= 0) { y = 0; return; }

        y+= quantity/quotient_y;

        if ((y-previous_y) <= -4) {
            previous_y = y;
        direction|= Direction.up; }

    return; }

    public void validate_all() {

        for (int count  = 0; count < 16; count++) {

            matrix.set_position((int)x+(count*16), (int)y);
            matrix.get_vertical();
        nametable.set_vertical(matrix.vertical); }

    return; }

    public void validate_x() {

        if ((direction & Direction.identity_x) == 0)
            return;

        if ((direction & Direction.left) != 0)
            matrix.set_position((int)x, (int)y);

        else matrix.set_position((int)x+240, (int)y);

        direction&= Direction.opposite_x;

        matrix.get_vertical();
        nametable.set_vertical(matrix.vertical);

    return; }

    public void validate_y() {

        if ((direction & Direction.identity_y) == 0)
            return;

        if ((direction & Direction.up) != 0)
            matrix.set_position((int)x, (int)y);

        else matrix.set_position((int)x, (int)y+240);

        direction&= Direction.opposite_y;

        matrix.get_horizontal();
        nametable.set_horizontal(matrix.horizontal);

    return; }

    public void update() {

        if (direction != Direction.idle) { validate_x(); validate_y(); }
        nametable.set_position((int)x, (int)y);

    return; }

    public void draw() {

        nametable.draw();

    return; }
}}
