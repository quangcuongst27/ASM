using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataService.Models
{
    public partial class ApartmentDbContext : DbContext
    {
        public ApartmentDbContext()
        {
        }

        public ApartmentDbContext(DbContextOptions<ApartmentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AroundProvider> AroundProvider { get; set; }
        public virtual DbSet<AroundProviderCategory> AroundProviderCategory { get; set; }
        public virtual DbSet<AroundProviderProduct> AroundProviderProduct { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BalanceSheet> BalanceSheet { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<BlockPoll> BlockPoll { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<HelpdeskRequest> HelpdeskRequest { get; set; }
        public virtual DbSet<HelpdeskRequestCategory> HelpdeskRequestCategory { get; set; }
        public virtual DbSet<HelpdeskRequestLog> HelpdeskRequestLog { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<HouseCategory> HouseCategory { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<NotificationChange> NotificationChange { get; set; }
        public virtual DbSet<NotificationObject> NotificationObject { get; set; }
        public virtual DbSet<Poll> Poll { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<ReceiptDetail> ReceiptDetail { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAnswerPoll> UserAnswerPoll { get; set; }
        public virtual DbSet<UserRateAroundProvider> UserRateAroundProvider { get; set; }
        public virtual DbSet<UtilServiceCategory> UtilServiceCategory { get; set; }
        public virtual DbSet<UtilServiceForHouseCat> UtilServiceForHouseCat { get; set; }
        public virtual DbSet<UtilityService> UtilityService { get; set; }
        public virtual DbSet<UtilityServiceRangePrices> UtilityServiceRangePrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=AMS;user id=sa;password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<AroundProvider>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Tel)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.AroundProviderCategory)
                    .WithMany(p => p.AroundProvider)
                    .HasForeignKey(d => d.AroundProviderCategoryId)
                    .HasConstraintName("FK_tbl_arround_srv_tbl_around_srv_cat");
            });

            modelBuilder.Entity<AroundProviderCategory>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<AroundProviderProduct>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.AroundProvider)
                    .WithMany(p => p.AroundProviderProduct)
                    .HasForeignKey(d => d.AroundProviderId)
                    .HasConstraintName("FK_AroundServiceProduct_AroundProvider");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<BalanceSheet>(entity =>
            {
                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.BalanceSheet)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Transaction_User");
            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.Property(e => e.BlockName).HasMaxLength(50);
            });

            modelBuilder.Entity<BlockPoll>(entity =>
            {
                entity.HasKey(e => new { e.BlockId, e.PollId })
                    .HasName("PK_BlockSurvey");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.BlockPoll)
                    .HasForeignKey(d => d.BlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlockSurvey_Block1");

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.BlockPoll)
                    .HasForeignKey(d => d.PollId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlockSurvey_Survey");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Comment_Post");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_User1");
            });

            modelBuilder.Entity<HelpdeskRequest>(entity =>
            {
                entity.Property(e => e.CloseDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DoneDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.HelpdeskRequestCat)
                    .WithMany(p => p.HelpdeskRequest)
                    .HasForeignKey(d => d.HelpdeskRequestCatId)
                    .HasConstraintName("FK_HelpdeskRequest_HelpdeskServiceCategory");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.HelpdeskRequest)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_tbl_h_desk_request_tbl_house");

                entity.HasOne(d => d.Supporter)
                    .WithMany(p => p.HelpdeskRequest)
                    .HasForeignKey(d => d.SupporterId)
                    .HasConstraintName("FK_HelpdeskRequest_User");
            });

            modelBuilder.Entity<HelpdeskRequestCategory>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<HelpdeskRequestLog>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DeadLine).HasColumnType("datetime");

                entity.HasOne(d => d.AssignToUser)
                    .WithMany(p => p.HelpdeskRequestLogAssignToUser)
                    .HasForeignKey(d => d.AssignToUserId)
                    .HasConstraintName("FK_HelpdeskRequestLog_User");

                entity.HasOne(d => d.ChangeFromUser)
                    .WithMany(p => p.HelpdeskRequestLogChangeFromUser)
                    .HasForeignKey(d => d.ChangeFromUserId)
                    .HasConstraintName("FK_HelpdeskRequestLog_User1");

                entity.HasOne(d => d.HelpdeskRequest)
                    .WithMany(p => p.HelpdeskRequestLog)
                    .HasForeignKey(d => d.HelpdeskRequestId)
                    .HasConstraintName("FK_HelpdeskRequestLog_HelpdeskReq");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.Property(e => e.AllowOtherView).HasDefaultValueSql("((1))");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DisplayMember).HasDefaultValueSql("((1))");

                entity.Property(e => e.Floor).HasMaxLength(255);

                entity.Property(e => e.HouseName).HasMaxLength(255);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK_House_Block");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_House_HouseType");
            });

            modelBuilder.Entity<HouseCategory>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OriginalUrl).HasColumnName("originalUrl");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnailUrl");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.Property(e => e.UserCropUrl).HasColumnName("userCropUrl");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Image_Post");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<NotificationChange>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.NotificationObjectId).HasColumnName("NotificationObjectID");

                entity.Property(e => e.Verb)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ActorNavigation)
                    .WithMany(p => p.NotificationChange)
                    .HasForeignKey(d => d.Actor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationChange_User1");

                entity.HasOne(d => d.NotificationObject)
                    .WithMany(p => p.NotificationChange)
                    .HasForeignKey(d => d.NotificationObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationChange_NotificationObject");
            });

            modelBuilder.Entity<NotificationObject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TargetObject).HasMaxLength(300);

                entity.Property(e => e.TargetObjectId).HasColumnName("TargetObjectID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NotificationObject)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationObject_User");
            });

            modelBuilder.Entity<Poll>(entity =>
            {
                entity.Property(e => e.Answer1).HasMaxLength(50);

                entity.Property(e => e.Answer2).HasMaxLength(50);

                entity.Property(e => e.Answer3).HasMaxLength(50);

                entity.Property(e => e.Answer4).HasMaxLength(50);

                entity.Property(e => e.Answer5).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(250);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Question).HasMaxLength(255);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tbl_post_tbl_user");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Bls)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.BlsId)
                    .HasConstraintName("FK_Receipt_BalanceSheet");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_tbl_receipt_tbl_house");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Receipt_User");
            });

            modelBuilder.Entity<ReceiptDetail>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.ReceiptDetail)
                    .HasForeignKey(d => d.ReceiptId)
                    .HasConstraintName("FK_ReceiptDetail_Receipt");

                entity.HasOne(d => d.UtilityService)
                    .WithMany(p => p.ReceiptDetail)
                    .HasForeignKey(d => d.UtilityServiceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tbl_receipt_detail_tbl_service_fee");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Report_Post");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Report_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(255);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.HasOne(d => d.Bls)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.BlsId)
                    .HasConstraintName("FK_Transaction_BalanceSheet");

                entity.HasOne(d => d.ReceiptDetail)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.ReceiptDetailId)
                    .HasConstraintName("FK_Transaction_ReceiptDetail");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Fullname).HasMaxLength(200);

                entity.Property(e => e.IdcreatedDate)
                    .HasColumnName("IDCreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idnumber)
                    .HasColumnName("IDNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImage).HasMaxLength(200);

                entity.Property(e => e.SendPasswordTo).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.House)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_User_House");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tbl_user_tbl_role");
            });

            modelBuilder.Entity<UserAnswerPoll>(entity =>
            {
                entity.HasKey(e => new { e.PollId, e.UserId })
                    .HasName("PK_UserDoServey");

                entity.Property(e => e.Answer).HasMaxLength(50);

                entity.Property(e => e.AnswerDate).HasColumnType("datetime");

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.UserAnswerPoll)
                    .HasForeignKey(d => d.PollId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDoServey_Survey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAnswerPoll)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDoServey_User");
            });

            modelBuilder.Entity<UserRateAroundProvider>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AroundProviderId });

                entity.HasOne(d => d.AroundProvider)
                    .WithMany(p => p.UserRateAroundProvider)
                    .HasForeignKey(d => d.AroundProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRateAroundProvider_AroundProvider");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRateAroundProvider)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRateAroundProvider_User");
            });

            modelBuilder.Entity<UtilServiceCategory>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<UtilServiceForHouseCat>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.HouseCat)
                    .WithMany(p => p.UtilServiceForHouseCat)
                    .HasForeignKey(d => d.HouseCatId)
                    .HasConstraintName("FK_UtilServiceForHouseCat_HouseCategory");

                entity.HasOne(d => d.UtilService)
                    .WithMany(p => p.UtilServiceForHouseCat)
                    .HasForeignKey(d => d.UtilServiceId)
                    .HasConstraintName("FK_UtilServiceForHouseCat_UtilityService");
            });

            modelBuilder.Entity<UtilityService>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.UtilSrvCat)
                    .WithMany(p => p.UtilityService)
                    .HasForeignKey(d => d.UtilSrvCatId)
                    .HasConstraintName("FK_UtilityService_UtilServiceCategory");
            });

            modelBuilder.Entity<UtilityServiceRangePrices>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.UtilityServiceRangePrices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_UtilityServiceRangePrices_UtilityService");
            });
        }
    }
}
