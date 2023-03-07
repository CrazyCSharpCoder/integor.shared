﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegorResponseDecoration
{
    public interface IResponseBodyDecorator
    {
        ResponseBodyDecorationResult Decorate(object? bodyObject);
    }
}
