﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Drawing;
using ImageEditor;

namespace DeblurModification
{
    public static class ImageComparator
    {
        public static double MeanSquareDeviationComparator(this Image source, Image image)
        {
            double[] sourceArray = Converter.ToDoubleArray(source);
            double[] distinationArray = Converter.ToDoubleArray(image);
            if (distinationArray.Length != sourceArray.Length)
                return 0;
            Func<double, double, double> comp = (s, d) => { return Math.Pow((Math.Abs(s - d) / 255),2); };

            double sum = 0;
            for (int i = 0 ; i < distinationArray.Length; i++)
                sum += comp(sourceArray[i], distinationArray[i]);
            sum /= distinationArray.Length;
            sum = Math.Sqrt(sum);
            return sum;
        }

        /// <summary>
        /// В процентном соотношении
        /// </summary>
        /// <param name="source"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public static double MeanSquareDeviationComparator(this double[,] source, double[,] image)
        {

            if (image.GetLength(0) != source.GetLength(0) || image.GetLength(1) != source.GetLength(1))
                    return 0;
            Func<double, double, double> comp = (s, d) => { return Math.Pow((Math.Abs(s - d) / 255), 2); };

            double sum = 0;
            for (int i = 0; i < image.GetLength(0); i++)
                for (int j = 0; j < image.GetLength(1); j++)

                sum += comp(source[i,j], image[i,j]);
            sum /= image.GetLength(0)*image.GetLength(1);
            sum = Math.Sqrt(sum);
            return sum;
        }



        /// <summary>
        /// Возвращает разницу между переходами двух изображений в процентном соотношенит
        /// </summary>
        /// <param name="source"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public static double Comparate(this Image source, Image image)
        {
            double[,] sourceRed = Converter.ToDoubleMatrix(source.OnlyRed());
            double[,] sourceGreen = Converter.ToDoubleMatrix(source.OnlyGreen());
            double[,] sourceBlue = Converter.ToDoubleMatrix(source.OnlyBlue());
            double[,] imageRed = Converter.ToDoubleMatrix(image.OnlyRed());
            double[,] imageGreen = Converter.ToDoubleMatrix(image.OnlyGreen());
            double[,] imageBlue = Converter.ToDoubleMatrix(image.OnlyBlue());
             
            double[,] sourceRedVerticalMask = new double[sourceRed.GetLength(0)-1,sourceRed.GetLength(1)];
            double[,] sourceRedHorizontalMask = new double[sourceRed.GetLength(0),sourceRed.GetLength(1)-1];
            double[,] sourceGreenVerticalMask = new double[sourceRed.GetLength(0)-1,sourceRed.GetLength(1)];
            double[,] sourceGreenHorizontalMask = new double[sourceRed.GetLength(0),sourceRed.GetLength(1)-1];
            double[,] sourceBlueVerticalMask = new double[sourceRed.GetLength(0)-1,sourceRed.GetLength(1)];
            double[,] sourceBlueHorizontalMask = new double[sourceRed.GetLength(0),sourceRed.GetLength(1)-1];
            
            double[,] imageRedVerticalMask = new double[sourceRed.GetLength(0)-1,sourceRed.GetLength(1)];
            double[,] imageRedHorizontalMask = new double[sourceRed.GetLength(0),sourceRed.GetLength(1)-1];
            double[,] imageGreenVerticalMask = new double[sourceRed.GetLength(0)-1,sourceRed.GetLength(1)];
            double[,] imageGreenHorizontalMask = new double[sourceRed.GetLength(0),sourceRed.GetLength(1)-1];
            double[,] imageBlueVerticalMask = new double[sourceRed.GetLength(0)-1,sourceRed.GetLength(1)];
            double[,] imageBlueHorizontalMask = new double[sourceRed.GetLength(0),sourceRed.GetLength(1)-1];
                        
            //Func<double,double>
            for (int i = 0; i < sourceBlueHorizontalMask.GetLength(0);i++)
                for (int j = 0; j < sourceBlueHorizontalMask.GetLength(1); j++)
                {
                    sourceRedHorizontalMask[i, j] = Math.Abs(sourceRed[i, j] - sourceRed[i, j + 1]);
                    sourceGreenHorizontalMask[i, j] = Math.Abs(sourceGreen[i, j] - sourceGreen[i, j + 1]);
                    sourceBlueHorizontalMask[i, j] = Math.Abs(sourceBlue[i, j] - sourceBlue[i, j + 1]);
                    imageRedHorizontalMask[i, j] = Math.Abs(imageRed[i, j] - imageRed[i, j + 1]);
                    imageGreenHorizontalMask[i, j] = Math.Abs(imageGreen[i, j] - imageGreen[i, j + 1]);
                    imageBlueHorizontalMask[i, j] = Math.Abs(imageBlue[i, j] - imageBlue[i, j + 1]);
                }

            for (int i = 0; i < sourceBlueVerticalMask.GetLength(0); i++)
                for (int j = 0; j < sourceBlueVerticalMask.GetLength(1); j++)
                {
                    sourceRedVerticalMask[i, j] = Math.Abs(sourceRed[i, j] - sourceRed[i+1, j]);
                    sourceGreenVerticalMask[i, j] = Math.Abs(sourceGreen[i, j] - sourceGreen[i+1, j]);
                    sourceBlueVerticalMask[i, j] = Math.Abs(sourceBlue[i, j] - sourceBlue[i+1, j]);
                    imageRedVerticalMask[i, j] = Math.Abs(imageRed[i, j] - imageRed[i+1, j]);
                    imageGreenVerticalMask[i, j] = Math.Abs(imageGreen[i, j] - imageGreen[i+1, j]);
                    imageBlueVerticalMask[i, j] = Math.Abs(imageBlue[i, j] - imageBlue[i+1, j]);
                }

            double verticalRedDifference = MeanSquareDeviationComparator(sourceRedHorizontalMask, imageRedHorizontalMask);
            double verticalGreenDifference = MeanSquareDeviationComparator(sourceGreenHorizontalMask, imageGreenHorizontalMask);
            double verticalBlueDifference = MeanSquareDeviationComparator(sourceBlueHorizontalMask, imageBlueHorizontalMask);
            double horizontalRedDifference = MeanSquareDeviationComparator(sourceRedHorizontalMask, imageRedHorizontalMask);
            double horizontalGreenDifference = MeanSquareDeviationComparator(sourceGreenHorizontalMask, imageGreenHorizontalMask);
            double horizontalBlueDifference = MeanSquareDeviationComparator(sourceBlueHorizontalMask, imageBlueHorizontalMask);
            double result = (verticalRedDifference + verticalGreenDifference + verticalBlueDifference + horizontalRedDifference +
                horizontalGreenDifference + horizontalBlueDifference)/6;
                return result;
        }
        /// <summary>
        /// Возвращает изображение, как разницу мужду переходами двух изображений
        /// </summary>
        /// <param name="source"></param>
        /// <param name="image"></param>
        /// <returns></returns>
       /* public static Image Comparate(this Image source, Image image)
        {
            double[,] sourceRed = Converter.ToDoubleMatrix(source.OnlyRed());
            double[,] sourceGreen = Converter.ToDoubleMatrix(source.OnlyGreen());
            double[,] sourceBlue = Converter.ToDoubleMatrix(source.OnlyBlue());
            double[,] imageRed = Converter.ToDoubleMatrix(image.OnlyRed());
            double[,] imageGreen = Converter.ToDoubleMatrix(image.OnlyGreen());
            double[,] imageBlue = Converter.ToDoubleMatrix(image.OnlyBlue());

            double[,] sourceRedVerticalMask = new double[sourceRed.GetLength(0) - 1, sourceRed.GetLength(1)];
            double[,] sourceRedHorizontalMask = new double[sourceRed.GetLength(0), sourceRed.GetLength(1) - 1];
            double[,] sourceGreenVerticalMask = new double[sourceRed.GetLength(0) - 1, sourceRed.GetLength(1)];
            double[,] sourceGreenHorizontalMask = new double[sourceRed.GetLength(0), sourceRed.GetLength(1) - 1];
            double[,] sourceBlueVerticalMask = new double[sourceRed.GetLength(0) - 1, sourceRed.GetLength(1)];
            double[,] sourceBlueHorizontalMask = new double[sourceRed.GetLength(0), sourceRed.GetLength(1) - 1];

            double[,] imageRedVerticalMask = new double[sourceRed.GetLength(0) - 1, sourceRed.GetLength(1)];
            double[,] imageRedHorizontalMask = new double[sourceRed.GetLength(0), sourceRed.GetLength(1) - 1];
            double[,] imageGreenVerticalMask = new double[sourceRed.GetLength(0) - 1, sourceRed.GetLength(1)];
            double[,] imageGreenHorizontalMask = new double[sourceRed.GetLength(0), sourceRed.GetLength(1) - 1];
            double[,] imageBlueVerticalMask = new double[sourceRed.GetLength(0) - 1, sourceRed.GetLength(1)];
            double[,] imageBlueHorizontalMask = new double[sourceRed.GetLength(0), sourceRed.GetLength(1) - 1];

            //Func<double,double>
            for (int i = 0; i < sourceBlueHorizontalMask.GetLength(0); i++)
                for (int j = 0; j < sourceBlueHorizontalMask.GetLength(1); j++)
                {
                    sourceRedHorizontalMask[i, j] = Math.Abs(sourceRed[i, j] - sourceRed[i, j + 1]);
                    sourceGreenHorizontalMask[i, j] = Math.Abs(sourceGreen[i, j] - sourceGreen[i, j + 1]);
                    sourceBlueHorizontalMask[i, j] = Math.Abs(sourceBlue[i, j] - sourceBlue[i, j + 1]);
                    imageRedHorizontalMask[i, j] = Math.Abs(imageRed[i, j] - imageRed[i, j + 1]);
                    imageGreenHorizontalMask[i, j] = Math.Abs(imageGreen[i, j] - imageGreen[i, j + 1]);
                    imageBlueHorizontalMask[i, j] = Math.Abs(imageBlue[i, j] - imageBlue[i, j + 1]);
                }

            for (int i = 0; i < sourceBlueVerticalMask.GetLength(0); i++)
                for (int j = 0; j < sourceBlueVerticalMask.GetLength(1); j++)
                {
                    sourceRedVerticalMask[i, j] = Math.Abs(sourceRed[i, j] - sourceRed[i + 1, j]);
                    sourceGreenVerticalMask[i, j] = Math.Abs(sourceGreen[i, j] - sourceGreen[i + 1, j]);
                    sourceBlueVerticalMask[i, j] = Math.Abs(sourceBlue[i, j] - sourceBlue[i + 1, j]);
                    imageRedVerticalMask[i, j] = Math.Abs(imageRed[i, j] - imageRed[i + 1, j]);
                    imageGreenVerticalMask[i, j] = Math.Abs(imageGreen[i, j] - imageGreen[i + 1, j]);
                    imageBlueVerticalMask[i, j] = Math.Abs(imageBlue[i, j] - imageBlue[i + 1, j]);
                }

            double verticalRedDifference = MeanSquareDeviationComparator(sourceRedHorizontalMask, imageRedHorizontalMask);
            double verticalGreenDifference = MeanSquareDeviationComparator(sourceGreenHorizontalMask, imageGreenHorizontalMask);
            double verticalBlueDifference = MeanSquareDeviationComparator(sourceBlueHorizontalMask, imageBlueHorizontalMask);
            double horizontalRedDifference = MeanSquareDeviationComparator(sourceRedHorizontalMask, imageRedHorizontalMask);
            double horizontalGreenDifference = MeanSquareDeviationComparator(sourceGreenHorizontalMask, imageGreenHorizontalMask);
            double horizontalBlueDifference = MeanSquareDeviationComparator(sourceBlueHorizontalMask, imageBlueHorizontalMask);
            double result = (verticalRedDifference + verticalGreenDifference + verticalBlueDifference + horizontalRedDifference +
                horizontalGreenDifference + horizontalBlueDifference) / 6;
            return result;
        }
        */
    }
}
