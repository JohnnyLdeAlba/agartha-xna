using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

// **************************************************
// * class: Nametable
// **************************************************

namespace agartha {

public class _vectortable : _table {

    public int x, y;
}

public class NameTable {

    public Core core;
    public Texture2D[] pattern_table;

    public Matrix matrix;
    public _vectortable table;

    public int x, y;
    public int row, column, index;

    public void initialize(Core core) {

        this.core = core;
        pattern_table = core.pattern_manager.table[1];

        table = new _vectortable();
        table.data = new int[256];

        for (int count = 0; count < 256; count++)
            table.data[count] = 0;

    return; }

    public void set_position(int x, int y) {

        this.x = x & 0xff;
        this.y = y & 0xff;

        row = this.x >> 4;
        column = this.y >> 4;

        index = (column << 4)+row;

    return; }

    public void set_horizontal(_table horizontal) {

        table.row = horizontal.row;
        table.column = horizontal.column;
        table.index = horizontal.index;

        for (int count = 0; count < 16; count++) {

            table.data[table.index] = horizontal.data[count];

            table.row++;
            table.index++;

        if (table.row >= 16) { table.row = 0;
            table.index = table.column << 4; }}

    return; }

    public void set_vertical(_table vertical) {

        table.row = vertical.row;
        table.column = vertical.column;
        table.index = vertical.index;

        for (int count = 0; count < 16; count++) {

            table.data[table.index] = vertical.data[count];

            table.column++;
            table.index+= 16;

        if (table.column >= 16) { table.column = 0;
            table.index = table.row; }}

    return; }

    public void set_row() {

        int value = 0;

        for (int count = 0; count < 16; count++) {

            value = table.data[table.index];

            core.display_manager.sprite_batch.Draw(pattern_table[value],
                new Vector2(table.x, table.y), Color.White);

            table.x+= 16;
            table.row++;
            table.index++;

        if (table.row >= 16) {
            table.row = 0;
        table.index = table.column << 4; }}

    return; }

    public void draw() {

        table.x = (this.x & 0xf0)-this.x;
        table.y = (this.y & 0xf0)-this.y;

        table.row = row;
        table.column = column;
        table.index = index;

        int start_x = table.x;

        for (int count = 0; count < 16; count++) {

            set_row();

            table.x = start_x;
            table.y+= 16;
            table.column++;
            table.index+= 16;

        if (table.column >= 16) {
            table.column = 0;
        table.index = row; }}

    return; }

}}
