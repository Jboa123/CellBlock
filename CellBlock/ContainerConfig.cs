using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellBlockLibrary;

namespace CellBlock
{
    public static class ContainerConfig
    {
        /// <summary>
        /// Register relevant classes for dependency injection.
        /// </summary>
        /// <returns></returns>
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<GUIManagement>().As<IGUIManagement>();
            builder.RegisterType<CloneGridAndSetBlock>().As<ICloneGridAndSetBlock>();
            builder.RegisterType<GUItoData>().InstancePerLifetimeScope().As<IGUItoData>();
            builder.RegisterType<DeepCloneGrid>().As<IDeepCloneGrid>();
            builder.RegisterType<SolvePuzzle>().As<ISolvePuzzle>();
            builder.RegisterType<PossibleBlockGeneration>().As<IPossibleBlockGeneration>();
            builder.RegisterType<GridAndCellIterations>().As<IGridAndCellIterations>();
            builder.RegisterType<Iterations>().As<IIterations>();
            builder.RegisterType<PossibleBlockRemoval>().As<IPossibleBlockRemoval>();
            builder.RegisterType<RunFullSolution>().As<IRunFullSolution>();

            //1 instance for the scope. This object holds a list of all Grid objects that have a solution
            // Also contains a dictionary of all the inputted values and their positions in the grid.
            builder.RegisterType<DisplaySolutionData>().InstancePerLifetimeScope().As<IDisplaySolutionData>();
            ///   builder.RegisterType<Grid>().InstancePerLifetimeScope().As<Grid>();

            return builder.Build();
        }
    }
}
