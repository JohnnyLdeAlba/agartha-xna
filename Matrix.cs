using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

// **************************************************
// * class: Matrix
// **************************************************

namespace agartha {

public class _table {

    public int[] data;
    public int column, row, index;
}

public class Matrix {

    public int[][] vector;                         // [width*height][16*16]

    public _table table, horizontal, vertical;

    public int x, y;
    public int column, row, index;
    public int width, height;

    public Matrix() {

        table = new _table();
        horizontal = new _table();
        vertical = new _table();

        horizontal.data = new int[16];
        vertical.data = new int[16];

    return; }

    public void set_vector(int[][] vector) {

        this.vector = vector;

    return; }

    public void set_position(int x, int y) {

        this.x = x; this.y = y;

        row = this.x >> 8;
        column = this.y >> 8;

        index = (column*width) + row;

        table.row = (this.x & 0xff) >> 4;
        table.column = (this.y & 0xff) >> 4;

        table.index = (table.column << 4)+table.row;

    return; }

    public void set_dimensions(int w, int h) {

        width = w; height = h;
    
    return; }

    public void get_table() {
        
        if ((row < 0) || (column < 0 )) return;

        if ((row >= width) || (column >= height)) {

            table.data = new int[256];
            for (int count = 0; count < 256; count++)
                table.data[count] = 0;

        return; }

        table.data = vector[index];

    return; }

    public void get_horizontal() {

        get_table();

        horizontal.row = table.row;
        horizontal.column = table.column;
        horizontal.index = table.index;

        for (int count = 0; count < 16; count++) {

            horizontal.data[count] = table.data[table.index];

            table.row++;
            table.index++;

        if (table.row >= 16) {
            
            table.row = 0;
            table.index = table.column << 4;

            row++;
            index = (column*width) + row;

         get_table(); }}

    return; }

    public void get_vertical() {

        get_table();

        vertical.row = table.row;
        vertical.column = table.column;
        vertical.index = table.index;

        for (int count = 0; count < 16; count++) {

            vertical.data[count] = table.data[table.index];
            
            table.column++;
            table.index+= 16;

        if (table.column >= 16) {
            
            table.column = 0;
            table.index = table.row;
        
            column++;
            index = (column*width) + row;

         get_table(); }}

    return; }

}}
