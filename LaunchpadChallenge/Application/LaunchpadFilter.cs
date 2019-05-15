using Domain;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application
{
    public class LaunchpadFilter
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public bool ExactMatch { get; set; }
        public bool UseDisjunction { get; set; }

        public IEnumerable<Launchpad> Filter(IEnumerable<Launchpad> launchpads)
        {
            var predicate = PredicateBuilder.New<Launchpad>(true);
            predicate = this.FilterOnId(predicate);
            predicate = this.FilterOnStatus(predicate);
            predicate = this.FilterOnName(predicate);

            return launchpads.Where(predicate);
        }

        private ExpressionStarter<Launchpad> FilterOnId(ExpressionStarter<Launchpad> predicate)
        {
            if (String.IsNullOrWhiteSpace(this.Id)) return predicate;
            Expression<Func<Launchpad, bool>> idPredicate;

            if (this.ExactMatch)
            {
                idPredicate = x => x.Id.ToLower() == this.Id.ToLower();
            }
            else
            {
                idPredicate = x => x.Id.ToString().ToLower().Contains(this.Id.ToLower());
            }
            return this.BuildPredicate(predicate, idPredicate);
        }

        private ExpressionStarter<Launchpad> FilterOnStatus(ExpressionStarter<Launchpad> predicate)
        {
            if (String.IsNullOrWhiteSpace(this.Status)) return predicate;
            Expression<Func<Launchpad, bool>> statusPredicate;

            if (this.ExactMatch)
            {
                statusPredicate = x => x.Status.ToLower() == this.Status.ToLower();
            }
            else
            {
                statusPredicate = x => x.Status.ToString().ToLower().Contains(this.Status.ToLower());
            }
            return this.BuildPredicate(predicate, statusPredicate);
        }

        private ExpressionStarter<Launchpad> FilterOnName(ExpressionStarter<Launchpad> predicate)
        {
            if (String.IsNullOrWhiteSpace(this.Name)) return predicate;
            Expression<Func<Launchpad, bool>> namePredicate;

            if (this.ExactMatch)
            {
                namePredicate = x => x.Name.ToLower() == this.Name.ToLower();
            }
            else
            {
                namePredicate = x => x.Name.ToString().ToLower().Contains(this.Name.ToLower());
            }
            return this.BuildPredicate(predicate, namePredicate);
        }

        private ExpressionStarter<Launchpad> BuildPredicate(ExpressionStarter<Launchpad> leftPredicate, ExpressionStarter<Launchpad> rightPredicate)
        {
            if (this.UseDisjunction)
            {
                return leftPredicate.Or(rightPredicate);
            }
            else
            {
                return leftPredicate.And(rightPredicate);

            }
        }
    }
}
