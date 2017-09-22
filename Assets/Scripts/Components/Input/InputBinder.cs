// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;

namespace Assets.Scripts.Components.Input
{
    public class InputBinder
    {
        public List<string> InputBindings { get; set; }
        public EInputPriority InputPriority { get; set; }
        public int Handle { get; set; }
    }
}
