﻿// <copyright file="FluentResizability.cs" company="Derek Chasse">
// Copyright (c) Derek Chasse. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Flexor
{
#pragma warning disable SA1600 // Elements should be documented
    public interface IFluentResizability
    {
    }

    public interface IFluentResizabilityWithValue : IFluentResizability
    {
        IFluentResizabilityWithValueOnBreakpoint IsAutomatic();

        IFluentResizabilityWithValueOnBreakpoint IsInitial();

        IFluentResizabilityWithValueOnBreakpoint CanGrow();

        IFluentResizabilityWithValueOnBreakpoint CanNotGrow();

        IFluentResizabilityWithValueOnBreakpoint CanNotShrink();
    }

    public interface IFluentResizabilityWithValueOnBreakpoint : IFluentResizability, IFluentReactive<IFluentResizabilityWithValue>
    {
    }
#pragma warning restore SA1600 // Elements should be documented

    /// <summary>
    /// Define the ability to resize an item is displayed in a flex-container.
    /// </summary>
    public class FluentResizability : IFluentResizabilityWithValueOnBreakpoint, IFluentResizabilityWithValue
    {
        private readonly Dictionary<Breakpoint, ResizabilityOption> breakpointDictionary = new Dictionary<Breakpoint, ResizabilityOption>();
        private ResizabilityOption valueToApply;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentResizability"/> class.
        /// </summary>
        public FluentResizability()
            : this(ResizabilityOption.Auto)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentResizability"/> class.
        /// </summary>
        /// <param name="initialValue">The initial <see cref="ResizabilityOption"/> across all media query breakpoints.</param>
        public FluentResizability(ResizabilityOption initialValue)
        {
            foreach (var breakpoint in Enum.GetValues(typeof(Breakpoint)).Cast<Breakpoint>())
            {
                this.breakpointDictionary.Add(breakpoint, initialValue);
            }
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValueOnBreakpoint CanGrow()
        {
            this.valueToApply = ResizabilityOption.Grow;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValueOnBreakpoint CanNotGrow()
        {
            this.valueToApply = ResizabilityOption.NoGrow;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValueOnBreakpoint CanNotShrink()
        {
            this.valueToApply = ResizabilityOption.NoShrink;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValueOnBreakpoint IsAutomatic()
        {
            this.valueToApply = ResizabilityOption.Auto;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValueOnBreakpoint IsInitial()
        {
            this.valueToApply = ResizabilityOption.None;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnDesktop()
        {
            this.breakpointDictionary[Breakpoint.Desktop] = this.valueToApply;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnDesktopAndLarger()
        {
            this.SetBreakpointValues(this.valueToApply, Breakpoint.Desktop, Breakpoint.Widescreen, Breakpoint.FullHD);
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnDesktopAndSmaller()
        {
            this.SetBreakpointValues(this.valueToApply, Breakpoint.Mobile, Breakpoint.Tablet, Breakpoint.Desktop);
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnFullHD()
        {
            this.breakpointDictionary[Breakpoint.FullHD] = this.valueToApply;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnFullHDAndSmaller()
        {
            this.SetBreakpointValues(this.valueToApply, Breakpoint.Mobile, Breakpoint.Tablet, Breakpoint.Desktop, Breakpoint.Widescreen, Breakpoint.FullHD);
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnMobile()
        {
            this.breakpointDictionary[Breakpoint.Mobile] = this.valueToApply;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnMobileAndLarger()
        {
            this.SetBreakpointValues(this.valueToApply, Breakpoint.Mobile, Breakpoint.Tablet, Breakpoint.Desktop, Breakpoint.Widescreen, Breakpoint.FullHD);
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnTablet()
        {
            this.breakpointDictionary[Breakpoint.Tablet] = this.valueToApply;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnTabletAndLarger()
        {
            this.SetBreakpointValues(this.valueToApply, Breakpoint.Tablet, Breakpoint.Desktop, Breakpoint.Widescreen, Breakpoint.FullHD);
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnTabletAndSmaller()
        {
            this.SetBreakpointValues(this.valueToApply, Breakpoint.Mobile, Breakpoint.Tablet);
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnWidescreen()
        {
            this.breakpointDictionary[Breakpoint.Widescreen] = this.valueToApply;
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnWidescreenAndLarger()
        {
            this.SetBreakpointValues(this.valueToApply, Breakpoint.Widescreen, Breakpoint.FullHD);
            return this;
        }

        /// <inheritdoc/>
        public IFluentResizabilityWithValue OnWidescreenAndSmaller()
        {
            this.SetBreakpointValues(this.valueToApply, Breakpoint.Mobile, Breakpoint.Tablet, Breakpoint.Desktop, Breakpoint.Widescreen);
            return this;
        }

        private void SetBreakpointValues(ResizabilityOption value, params Breakpoint[] breakpoints)
        {
            foreach (var breakpoint in breakpoints)
            {
                this.breakpointDictionary[breakpoint] = value;
            }
        }
    }
}
