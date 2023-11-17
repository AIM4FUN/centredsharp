﻿using CentrED.Map;
using static CentrED.Application;

namespace CentrED.Tools;

public class RemoveTool : Tool
{
    public override string Name => "RemoveTool";

    private bool _pressed;
    private StaticObject _focusObject;

    public override void OnMouseEnter(TileObject? o)
    {
        if (o is StaticObject so)
        {
            so.Alpha = 0.2f;
        }
    }

    public override void OnMouseLeave(TileObject? o)
    {
        if (o is StaticObject so)
        {
            so.Alpha = 1.0f;
        }
    }

    public override void OnMousePressed(TileObject? o)
    {
        if (!_pressed && o is StaticObject so)
        {
            _pressed = true;
            _focusObject = so;
        }
    }

    public override void OnMouseReleased(TileObject? o)
    {
        if (_pressed && o is StaticObject so && so == _focusObject)
        {
            CEDClient.Remove(_focusObject.StaticTile);
        }
        _pressed = false;
    }
}