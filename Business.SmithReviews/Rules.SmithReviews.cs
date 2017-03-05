using Models.SmithReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.SmithReviews
{
    public static class Rules
    {
        public static class Review {
            public static bool RatingIsBewtween1And5(ReviewModel item) {
                if (item.Rating >= 1 && item.Rating <= 5)
                    return true;
                throw new RuleException();
            }
            public static bool CommentIsLongerThan4Characters(ReviewModel item) {
                if (item.Comment.Length > 4)
                    return true;
                throw new RuleException();
            }
        }
    }
}
