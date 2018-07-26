﻿using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public interface IPainterTool
    {
        List<DrawingItem> Draw(List<DrawingItem> drawingList, Point drawingStartPoint, Point drawingEndPoint);
    }
}