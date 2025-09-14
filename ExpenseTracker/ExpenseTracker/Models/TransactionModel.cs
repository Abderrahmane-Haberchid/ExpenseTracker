using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseTracker.Enum;

namespace ExpenseTracker.Models
{
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Category { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [MaxLength(500)]
        public string? Notes { get; set; }
        

        [NotMapped]
        public string FormattedDate => Date.ToString("MMM dd, yyyy");

        [NotMapped]
        public string FormattedDateTime => Date.ToString("MMM dd, yyyy h:mm tt");

        [NotMapped]
        public string CategoryIcon => GetCategoryIcon(Category);

        [NotMapped]
        public string TypeColor => Type == TransactionType.INCOME ? "#22C55E" : "#EF4444";

        // Helper method to get category icons
        private static string GetCategoryIcon(string category)
        {
            return category?.ToLower() switch
            {
                "food - dining" or "food" or "restaurant" => "🍕",
                "groceries" => "🍽️",
                "transportation" or "transport" or "gas" => "🚗",
                "shopping" or "retail" => "🛍️",
                "entertainment" or "fun" => "🎬",
                "bills" or "utilities" => "💡",
                "healthcare" or "medical" => "🏥",
                "education" or "learning" => "📚",
                "travel" or "vacation" => "✈️",
                "salary" or "income" => "💼",
                "freelance" or "side hustle" => "💰",
                "investment" or "returns" => "📈",
                "gift" or "bonus" => "🎁",
                "other" => "📝",
                _ => "💳"
            };
        }

        // Helper method to get relative date description
        [NotMapped]
        public string RelativeDate
        {
            get
            {
                var today = DateTime.Today;
                var transactionDate = Date.Date;

                if (transactionDate == today)
                    return "Today";
                else if (transactionDate == today.AddDays(-1))
                    return "Yesterday";
                else if (transactionDate >= today.AddDays(-7))
                    return $"{(today - transactionDate).Days} days ago";
                else if (transactionDate >= today.AddDays(-30))
                {
                    var weeks = (today - transactionDate).Days / 7;
                    return weeks == 1 ? "1 week ago" : $"{weeks} weeks ago";
                }
                else if (transactionDate.Year == today.Year)
                    return transactionDate.ToString("MMM dd");
                else
                    return transactionDate.ToString("MMM dd, yyyy");
            }
        }

        // Validation method
        public bool IsValid(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (Amount <= 0)
            {
                errorMessage = "Amount must be greater than zero";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                errorMessage = "Name is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Category))
            {
                errorMessage = "Category is required";
                return false;
            }

            return true;
        }

    }

}