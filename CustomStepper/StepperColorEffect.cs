﻿using System.Linq;

using Xamarin.Forms;

namespace CustomStepper
{
    public static class StepperColorEffect
    {
        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached(nameof(Color),
                typeof(Color),
                typeof(Stepper),
                Color.Gray,
                propertyChanged: OnStepperColorChanged);

        public static Color GetColorProperty(BindableObject view) => (Color)view.GetValue(ColorProperty);

        public static void SetColorProperty(BindableObject view, Color value) => view.SetValue(ColorProperty, value);

        static void OnStepperColorChanged(BindableObject bindable, object oldValue, object newValue) => UpdateEffect(bindable);

        static void UpdateEffect(BindableObject bindable)
        {
            switch (bindable)
            {
                case Stepper stepper:
                    RemoveEffect(stepper);
                    stepper.Effects.Add(new StepperColorRoutingEffect());
                    break;
            }
        }

        static void RemoveEffect(Stepper entry)
        {
            var effectToRemoveList = entry.Effects.Where(e => e is StepperColorRoutingEffect).ToList();

            foreach (var entryReturnTypeEffect in effectToRemoveList)
                entry.Effects.Remove(entryReturnTypeEffect);
        }
    }

    class StepperColorRoutingEffect : RoutingEffect
    {
        public StepperColorRoutingEffect() : base("CustomStepper.StepperColorEffect")
        {
        }
    }
}
