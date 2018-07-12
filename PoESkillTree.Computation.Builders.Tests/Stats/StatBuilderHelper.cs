﻿using System.Linq;
using PoESkillTree.Computation.Builders.Entities;
using PoESkillTree.Computation.Builders.Stats;
using PoESkillTree.Computation.Common;
using PoESkillTree.Computation.Common.Builders.Entities;
using PoESkillTree.Computation.Common.Builders.Stats;

namespace PoESkillTree.Computation.Builders.Tests.Stats
{
    internal static class StatBuilderHelper
    {
        public static ICoreStatBuilder CreateStatBuilder(string identity, params Entity[] entities) =>
            CreateStatBuilder(identity, new EntityBuilder(entities));

        public static ICoreStatBuilder CreateStatBuilder(string identity, IEntityBuilder entityBuilder = null)
        {
            IStat CreateStat(Entity entity) => new Stat(identity, entity);
            return new LeafCoreStatBuilder(CreateStat, entityBuilder);
        }

        public static ICoreStatBuilder CreateStatBuilder(IStat stat, IEntityBuilder entityBuilder = null) =>
            new LeafCoreStatBuilder(_ => stat, entityBuilder);

        public static IStat BuildToSingleStat(this IStatBuilder @this) =>
            @this.BuildToSingleResult().Stats.Single();

        public static StatBuilderResult BuildToSingleResult(this IStatBuilder @this) =>
            @this.Build(default, null).Single();
    }
}