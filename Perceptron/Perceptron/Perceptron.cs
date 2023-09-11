using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perceptron
{
    internal class Perceptron
    {
        private double[] inputs;
        private double[] weights;
        private double bias;
        private double learning_rate;

        // Set all weights and node thresholds to small random numbers (-1..1)
        public Perceptron()
        {
            Random rand = new Random();
            weights = new double[2];
            for(int i = 0; i < weights.Length; i++)
            {
                weights[i] = rand.NextDouble() * (1 - (-1)) + (-1);
            }
            bias = 1;
            learning_rate = 1;
        }

        // Compute for activation
        public int activation(double[] inputs)
        {
            this.inputs = inputs;
            double r = 0;
            
            for(int i = 0; i < inputs.Length; i++)
            {
                r += inputs[i] * weights[i];
            }
            r += bias;
            return hard_limiting(r);
        }

        public void adjust(int desired_output)
        {
            int actual_output = activation(inputs);
            int delta = desired_output - actual_output;

            // adjust weights and bias
            for(int i = 0; i < weights.Length; i++)
            {
                weights[i] += inputs[i] * learning_rate * delta;
            }
            bias += delta * learning_rate;
        }

        // Limiting Function
        public int hard_limiting (double y)
        {
            return y > 0 ? 1 : -1;
        }


    }
}
