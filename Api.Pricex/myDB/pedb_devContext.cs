using Api.Pricex.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Pricex.myDB
{
    public partial class pedb_devContext : DbContext
    {
        public pedb_devContext()
        {
        }

        public pedb_devContext(DbContextOptions<pedb_devContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AutoCancelOfferFlags> AutoCancelOfferFlags { get; set; }
        public virtual DbSet<BedTypes> BedTypes { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<BankName> BankName { get; set; }
        public virtual DbSet<Campaigns> Campaigns { get; set; }
        public virtual DbSet<Coupons> Coupons { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Facilities> Facilities { get; set; }
        public virtual DbSet<FacilitiesGroupType> FacilitiesGroupType { get; set; }
        public virtual DbSet<FailedJobs> FailedJobs { get; set; }
        public virtual DbSet<Favourites> Favourites { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Guests> Guests { get; set; }
        public virtual DbSet<HotelBranchConfigs> HotelBranchConfigs { get; set; }
        public virtual DbSet<HotelBranches> HotelBranches { get; set; }
        public virtual DbSet<HotelFacilities> HotelFacilities { get; set; }
        public virtual DbSet<HotelLandmarks> HotelLandmarks { get; set; }
        public virtual DbSet<HotelPayments> HotelPayments { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<InvoiceCoupon> InvoiceCoupon { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Keywords> Keywords { get; set; }
        public virtual DbSet<Landmarks> Landmarks { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<LocationDistricts> LocationDistricts { get; set; }
        public virtual DbSet<LocationGeographies> LocationGeographies { get; set; }
        public virtual DbSet<LocationProvinces> LocationProvinces { get; set; }
        public virtual DbSet<LocationSubdistricts> LocationSubdistricts { get; set; }
        public virtual DbSet<LocationLandmark> LocationLandmarks { get; set; }
        public virtual DbSet<MappingUsers> MappingUsers { get; set; }
        public virtual DbSet<MessageTexts> MessageTexts { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<OauthAccessTokens> OauthAccessTokens { get; set; }
        public virtual DbSet<OauthAuthCodes> OauthAuthCodes { get; set; }
        public virtual DbSet<OauthClients> OauthClients { get; set; }
        public virtual DbSet<OauthPersonalAccessClients> OauthPersonalAccessClients { get; set; }
        public virtual DbSet<OauthRefreshTokens> OauthRefreshTokens { get; set; }
        public virtual DbSet<OfferNotes> OfferNotes { get; set; }
        public virtual DbSet<OfferPaymentTransactions> OfferPaymentTransactions { get; set; }
        public virtual DbSet<OfferRooms> OfferRooms { get; set; }
        public virtual DbSet<OfferStatuses> OfferStatuses { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }
        public virtual DbSet<PasswordResets> PasswordResets { get; set; }
        public virtual DbSet<PaymentLogs> PaymentLogs { get; set; }
        public virtual DbSet<PaymentRequestLog> PaymentRequestLog { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<RoomFacilities> RoomFacilities { get; set; }
        public virtual DbSet<RoomPrices> RoomPrices { get; set; }
        public virtual DbSet<RoomTypes> RoomTypes { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<RpsField> RpsField { get; set; }
        public virtual DbSet<RpsHead> RpsHead { get; set; }
        public virtual DbSet<StdEmployee> StdEmployee { get; set; }
        public virtual DbSet<StdSysApplication> StdSysApplication { get; set; }
        public virtual DbSet<StdSysConfig> StdSysConfig { get; set; }
        public virtual DbSet<StdSysMenu> StdSysMenu { get; set; }
        public virtual DbSet<StdSysParam> StdSysParam { get; set; }
        public virtual DbSet<StdSysPriv> StdSysPriv { get; set; }
        public virtual DbSet<StdSysQuery> StdSysQuery { get; set; }
        public virtual DbSet<SystemProcessLogs> SystemProcessLogs { get; set; }
        public virtual DbSet<Terms> Terms { get; set; }
        public virtual DbSet<TokenFacebook> TokenFacebook { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<TypeMappingFacilities> TypeMappingFacilities { get; set; }
        public virtual DbSet<UiTexts> UiTexts { get; set; }
        public virtual DbSet<UserCoupon> UserCoupon { get; set; }
        public virtual DbSet<UserHotelPermissions> UserHotelPermissions { get; set; }
        public virtual DbSet<UserProcessLogs> UserProcessLogs { get; set; }
        public virtual DbSet<UserRecentViews> UserRecentViews { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAdmin> UsersAdmin { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<UserGroupAccess> UserGroupAccess { get; set; }
        public virtual DbSet<UserAccess> UserAccess { get; set; }
        public virtual DbSet<Versions> Versions { get; set; }
        public virtual DbSet<HotelRoomType> HotelRoomType { get; set; }
        public virtual DbSet<ContactPerson> ContactPerson { get; set; }
        public virtual DbSet<HotelRoomSetting> HotelRoomSettings { get; set; }
        public virtual DbSet<RoomSettingAmenities> RoomSettingAmenities { get; set; }
        public virtual DbSet<RoomSettingFoodAndDrink> RoomSettingFoodAndDrinks { get; set; }
        public virtual DbSet<HotelTransaction> HotelTransaction { get; set; }
        public virtual DbSet<RoomRateAllotment> RoomRateAllotment { get; set; }
        public virtual DbSet<AmendBookingHotel> AmendBookingHotel { get; set; }
        public virtual DbSet<BookingReport> BookingReport { get; set; }
        public virtual DbSet<CaseSummary> CaseSummary { get; set; }
        public virtual DbSet<HotelVoucher> HotelVoucher { get; set; }
        public virtual DbSet<ReasonReject> ReasonReject { get; set; }
        public virtual DbSet<TermAndConditionStampRead> TermAndConditionStampRead { get; set; }
        public virtual DbSet<TermAndCondition> TermAndCondition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=203.154.162.242;port=3309;user=DEVFeyverly;password=gf[lkp2*;database=pedb_dev");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoCancelOfferFlags>(entity =>
            {
                entity.ToTable("auto_cancel_offer_flags");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BedTypes>(entity =>
            {
                entity.ToTable("bed_types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1) unsigned zerofill");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookingReport>(entity =>
            {
                entity.ToTable("booking_report");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Review)
                     .HasColumnName("review")
                     .HasMaxLength(100)
                     .IsUnicode(false);

                entity.Property(e => e.BookingId)
                    .HasColumnName("booking_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Seq)
                    .HasColumnName("seq")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activitie)
                    .HasColumnName("activitie")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CaseSummary>(entity =>
            {
                entity.ToTable("case_summary");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.From)
                    .HasColumnName("from")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookingId)
                    .HasColumnName("booking_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Seq)
                    .HasColumnName("seq")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Channel)
                    .HasColumnName("channel")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                   .HasColumnName("note")
                   .HasMaxLength(800)
                   .IsUnicode(false);

                entity.Property(e => e.By)
                   .HasColumnName("by")
                   .HasMaxLength(100)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<HotelTransaction>(entity =>
            {
                entity.ToTable("hotel_transaction");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branch_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Customer)
                   .HasColumnName("customer")
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.Property(e => e.TransactionTime).HasColumnName("transaction_time");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnName("transaction_amount")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Commission)
                      .HasColumnName("commission")
                      .HasMaxLength(255)
                      .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.OutStanding)
                    .HasColumnName("outstanding")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentStatus)
                      .HasColumnName("payment_status")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.Invoice)
                      .HasColumnName("invoice")
                      .HasMaxLength(255)
                      .IsUnicode(false);

                entity.Property(e => e.Params)
                      .HasColumnName("params")
                      .HasMaxLength(400)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<AmendBookingHotel>(entity =>
            {
                entity.ToTable("amend_booking_hotel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookingId)
                     .HasColumnName("booking_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                      .HasColumnName("users_id")
                      .HasColumnType("int(11)");

                entity.Property(e => e.Hotel)
                    .HasColumnName("hotel")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoomType)
                     .HasColumnName("room_type")
                     .HasMaxLength(100)
                     .IsUnicode(false);

                entity.Property(e => e.PhoneHotel)
                      .HasColumnName("phone_hotel")
                      .HasColumnType("int(10)");


                entity.Property(e => e.EmailHotel)
                      .HasColumnName("email_hotel")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.CheckIn).HasColumnName("check_in");

                entity.Property(e => e.CheckOut).HasColumnName("check_out");

                entity.Property(e => e.Night)
                      .HasColumnName("night")
                      .HasColumnType("int(11)");

                entity.Property(e => e.NumberOfRoom)
                      .HasColumnName("number_of_room")
                      .HasColumnType("int(11)");

                entity.Property(e => e.Adult)
                     .HasColumnName("adult")
                     .HasColumnType("int(11)");

                entity.Property(e => e.Children)
                     .HasColumnName("children")
                     .HasColumnType("int(11)");

                entity.Property(e => e.IncludedBreakfast).HasColumnName("breakfast_included");

                entity.Property(e => e.SpecialRequest)
                        .IsRequired()
                        .HasColumnName("special_request")
                        .HasMaxLength(800)
                        .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelRoomType>(entity =>
            {
                entity.HasMany<Photos>(q => q.Photos)
                    .WithOne(c => c.hotelRoomType)
                    .HasForeignKey(q => q.ReferenceId)
                    ;

                entity.ToTable("hotel_room_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotelId)
                     .HasColumnName("hotel_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.RoomNameEn)
                    .HasColumnName("room_name_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoomNameTh)
                     .HasColumnName("room_name_th")
                     .HasMaxLength(100)
                     .IsUnicode(false);

                entity.Property(e => e.RoomDetailTh)
                      .HasColumnName("room_detail_th")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.RoomDetailEn)
                      .HasColumnName("room_detail_en")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.MaxAdult)
                      .HasColumnName("max_adult")
                      .HasColumnType("int(11)");

                entity.Property(e => e.MaxChildren)
                      .HasColumnName("max_children")
                      .HasColumnType("int(11)");

                entity.Property(e => e.Breakfast).HasColumnName("breakfast");

                entity.Property(e => e.RoomOnly).HasColumnName("room_only");

                entity.Property(e => e.RoomSize)
                      .HasColumnName("room_size")
                      .HasColumnType("int(11)");

                entity.Property(e => e.ExtraBed)
                      .HasColumnName("extra_bed")
                      .HasColumnType("int(11)");

                entity.Property(e => e.View)
                        .HasColumnName("view")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.ToTable("bookings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CheckinCode)
                    .HasColumnName("checkin_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerCheckinAt).HasColumnName("customer_checkin_at");

                entity.Property(e => e.CustomerCheckoutAt).HasColumnName("customer_checkout_at");

                entity.Property(e => e.Memo).HasColumnName("memo");

                entity.Property(e => e.OfferId)
                    .HasColumnName("offer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookingStatusId)
                     .HasColumnName("booking_status_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.ReasonRejectId)
                     .HasColumnName("reason_reject_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.ReasonCancelId)
                      .HasColumnName("reason_cancel_id")
                      .HasColumnType("int(11)");

                entity.Property(e => e.RejectedAt).HasColumnName("rejected_at");

                entity.Property(e => e.CanceledAt).HasColumnName("canceled_at");

                entity.Property(e => e.RejectedBy)
                       .HasColumnName("rejected_by")
                       .HasMaxLength(100)
                       .IsUnicode(false);

                entity.Property(e => e.CanceledBy)
                       .HasColumnName("canceled_by")
                       .HasMaxLength(100)
                       .IsUnicode(false);

                entity.Property(e => e.LeadGuestName)
                       .HasColumnName("lead_first_name")
                       .HasMaxLength(100)
                       .IsUnicode(false);

                entity.Property(e => e.Surname)
                       .HasColumnName("lead_last_name")
                       .HasMaxLength(100)
                       .IsUnicode(false);
            });

            modelBuilder.Entity<Campaigns>(entity =>
            {
                entity.ToTable("campaigns");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.ExpiredAt).HasColumnName("expired_at");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Coupons>(entity =>
            {
                entity.ToTable("coupons");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CampaignId)
                    .HasColumnName("campaign_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.ExpiredAt).HasColumnName("expired_at");

                entity.Property(e => e.Maximum)
                    .HasColumnName("maximum")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'fix'")
                    .HasComment("fix,percent");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.ToTable("currencies");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.FlagImg)
                    .HasColumnName("flag_img")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("update_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("update_date")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Devices>(entity =>
            {
                entity.ToTable("devices");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("device_id")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceToken)
                    .IsRequired()
                    .HasColumnName("device_token")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RevokedAt)
                    .HasColumnName("revoked_at")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Facilities>(entity =>
            {
                entity.ToTable("facilities");

                entity.HasMany<FacilitiesGroupType>(q => q.FacilitiesGroupTypes)
                     .WithOne(c => c.Facilities)
                     .HasForeignKey(q => q.FacilitiesId)
                   ;

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacilitiesGroupType>(entity =>
            {
                entity.ToTable("facilities_group_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FacilitiesId)
                    .HasColumnName("facilities_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .HasColumnName("name_th")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FailedJobs>(entity =>
            {
                entity.ToTable("failed_jobs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Connection)
                    .IsRequired()
                    .HasColumnName("connection");

                entity.Property(e => e.Exception)
                    .IsRequired()
                    .HasColumnName("exception")
                    .HasColumnType("longtext");

                entity.Property(e => e.FailedAt)
                    .HasColumnName("failed_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("payload")
                    .HasColumnType("longtext");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasColumnName("queue");
            });

            modelBuilder.Entity<Favourites>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoomId })
                    .HasName("PRIMARY");

                entity.ToTable("favourites");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Guests>(entity =>
            {
                entity.ToTable("guests");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.BookingId)
                    .HasColumnName("booking_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CitizenId)
                    .HasColumnName("citizen_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PassportId)
                    .HasColumnName("passport_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TermAndConditionStampRead>(entity =>
            {
                entity.ToTable("terms_and_condition_stamp_read");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TermId)
                   .HasColumnName("term_id")
                   .HasColumnType("int(11)");

                entity.Property(e => e.Version)
                   .HasColumnName("version")
                   .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ReadFrom)
                    .HasColumnName("read_from")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmCheckbox)
                    .HasColumnName("confirm_checkbox");

                entity.Property(e => e.UserId)
                       .HasColumnName("user_id")
                       .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TermAndCondition>(entity =>
            {
                entity.ToTable("term_and_condition");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Version)
                   .HasColumnName("version")
                   .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                      .HasColumnName("content")
                      .HasMaxLength(1000)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<HotelBranchConfigs>(entity =>
            {
                entity.ToTable("hotel_branch_configs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branch_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RequireCheckinCode)
                    .HasColumnName("require_checkin_code")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelBranches>(entity =>
            {
                entity.HasMany<Photos>(q => q.Photos)
                  .WithOne(c => c.HotelBranches)
                  .HasForeignKey(q => q.ReferenceId)
                ;

                entity.HasMany<LocationLandmark>(l => l.Location_Landmark)
                 .WithOne(c => c.HotelBranches)
                 .HasForeignKey(q => q.HotelBranchId)
                ;

                entity.ToTable("hotel_branches");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                     .HasColumnName("user_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.AddressEn)
                    .HasColumnName("address_en")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AddressTh)
                    .HasColumnName("address_th")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictId)
                    .HasColumnName("district_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotelId)
                    .HasColumnName("hotel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LandmarkEn)
                    .HasColumnName("landmark_en")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LandmarkTh)
                    .HasColumnName("landmark_th")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lng).HasColumnName("lng");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Commission).HasColumnName("commission");

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .HasColumnName("name_th")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubDistrictId)
                    .HasColumnName("sub_district_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tags)
                    .HasColumnName("tags")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                 .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                //entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.CheckIn).HasColumnName("check_in");

                entity.Property(e => e.CheckOut).HasColumnName("check_out");

                entity.Property(e => e.IsAvailable).HasColumnName("is_available");

                entity.Property(e => e.Commission)
                    .HasColumnName("commission")
                    .HasColumnType("int(11)");


                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                     .HasColumnName("status")
                     .HasColumnType("int(11)");
            });

            modelBuilder.Entity<HotelFacilities>(entity =>
            {
                entity.HasKey(e => new { e.Id })
                    .HasName("PRIMARY");

                entity.ToTable("hotel_facilities");

                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branch_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FacilitiesId)
                      .HasColumnName("facilities_id")
                      .HasMaxLength(1000)
                      .IsUnicode(false);

                entity.Property(e => e.UserId)
                       .HasColumnName("user_id")
                       .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FacilitiesGroupTypeId)
                      .HasColumnName("facilities_group_type_id")
                      .HasMaxLength(1000)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<HotelRoomSetting>(entity =>
            {
                entity.ToTable("hotel_room_setting");

                entity.Property(e => e.HotelId)
                    .HasColumnName("hotel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branch_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasColumnType("int(11)");

                entity.Property(e => e.Amenitie)
                     .HasColumnName("amenitie")
                     .HasMaxLength(1000)
                     .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                     .HasColumnName("created_by")
                     .HasMaxLength(100)
                     .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomSettingFoodAndDrink>(entity =>
            {
                entity.ToTable("room_setting_food_drink");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotelRoomSettingId)
                  .HasColumnName("hotel_room_setting_id")
                  .HasColumnType("int(11)");

                entity.Property(e => e.DiningArea)
                  .HasColumnName("dining_area")
                  .HasMaxLength(250)
                  .IsUnicode(false);

                entity.Property(e => e.DiningTable)
                   .HasColumnName("dining_table")
                   .HasMaxLength(250)
                   .IsUnicode(false);

                entity.Property(e => e.FreeBottledWater)
                     .HasColumnName("free_bottled_water")
                     .HasMaxLength(250)
                     .IsUnicode(false);

                entity.Property(e => e.ComplimentaryTeaAndCoffee)
                     .HasColumnName("complimentary_tea_and_coffee")
                     .HasMaxLength(250)
                     .IsUnicode(false);

                entity.Property(e => e.CoffeeTeaMaker)
                     .HasColumnName("coffee/tea_maker")
                     .HasMaxLength(250)
                     .IsUnicode(false);

                entity.Property(e => e.MiniBar)
                     .HasColumnName("mini_bar")
                     .HasMaxLength(4000)
                     .IsUnicode(false);

                entity.Property(e => e.Fruits)
                     .HasColumnName("fruits")
                     .HasMaxLength(4000)
                     .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomSettingAmenities>(entity =>
            {
                entity.ToTable("room_setting_amenities");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                     .HasColumnName("name")
                     .HasMaxLength(100)
                     .IsUnicode(false);

                entity.Property(e => e.Type)
                   .HasColumnName("type")
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelLandmarks>(entity =>
            {
                entity.HasKey(e => new { e.HotelBranchId, e.LandmarkId })
                    .HasName("PRIMARY");

                entity.ToTable("hotel_landmarks");

                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branch_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LandmarkId)
                    .HasColumnName("landmark_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelPayments>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.HotelId, e.HotelBranchId })
                    .HasName("PRIMARY");

                entity.ToTable("hotel_payments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HotelId)
                    .HasColumnName("hotel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branch_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                     .HasColumnName("user_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.AccountHolders)
                    .HasColumnName("account_holders")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("account_number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasColumnName("bank_name")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                //entity.Property(e => e.BankShortName)
                //    .HasColumnName("bank_short_name")
                //    .HasMaxLength(20)
                //    .IsUnicode(false);

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branch_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasColumnName("branch_name")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                //entity.Property(e => e.Currency)
                //    .HasColumnName("currency")
                //    .HasMaxLength(20)
                //    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("payment_method")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                //entity.Property(e => e.PaymentType)
                //    .HasColumnName("payment_type")
                //    .HasMaxLength(4000)
                //    .IsUnicode(false);

                entity.Property(e => e.SwiftCode)
                    .HasColumnName("swift_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.ToTable("hotels");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotelVoucherId)
                   .HasColumnName("hotel_voucher_id")
                   .HasColumnType("int(11)");

                entity.Property(e => e.CheckinTime).HasColumnName("checkin_time");

                entity.Property(e => e.CheckoutTime).HasColumnName("checkout_time");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .HasColumnName("name_th")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InvoiceCoupon>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceId, e.CouponId })
                    .HasName("PRIMARY");

                entity.ToTable("invoice_coupon");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CouponId)
                    .HasColumnName("coupon_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.DiscountType)
                    .IsRequired()
                    .HasColumnName("discount_type")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'fix'")
                    .HasComment("fix,percent");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("invoices");

                entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.GatewayUrl)
                    .HasColumnName("gateway_url")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Invoice)
                    .HasColumnName("invoice")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("grand_total")
                    .HasColumnType("decimal(20,2)");

                //entity.Property(e => e.Id)
                //    .IsRequired()
                //    .HasColumnName("id")
                //    .HasMaxLength(15)
                //    .IsUnicode(false);

                entity.Property(e => e.InvoiceableId)
                    .IsRequired()
                    .HasColumnName("invoiceable_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceableType)
                    .IsRequired()
                    .HasColumnName("invoiceable_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.GateWay)
                   .HasColumnName("gate_way")
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(e => e.InvoiceNumber)
                    .HasColumnName("invoice_number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CardNumber)
                    .HasColumnName("card_number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .HasColumnName("card_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ResultCallback).HasColumnName("result_callback");

                entity.Property(e => e.ResultStatus)
                    .HasColumnName("result_status")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.ToTable("jobs");

                entity.HasIndex(e => new { e.Queue, e.ReservedAt })
                    .HasName("jobs_queue_reserved_at_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Attempts)
                    .HasColumnName("attempts")
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.AvailableAt)
                    .HasColumnName("available_at")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectRefId)
                    .HasColumnName("object_ref_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ObjectType)
                    .HasColumnName("object_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("payload")
                    .HasColumnType("longtext");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasColumnName("queue")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReservedAt)
                    .HasColumnName("reserved_at")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<Keywords>(entity =>
            {
                entity.ToTable("keywords");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceId)
                    .HasColumnName("reference_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Landmarks>(entity =>
            {
                entity.ToTable("landmarks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .HasColumnName("name_th")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.ToTable("languages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<LocationDistricts>(entity =>
            {
                entity.ToTable("location_districts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(5)");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasColumnName("name_en")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .IsRequired()
                    .HasColumnName("name_th")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(5)");

                entity.Property(e => e.ZipCodeBody)
                    .IsRequired()
                    .HasColumnName("zip_code_body")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationGeographies>(entity =>
            {
                entity.ToTable("location_geographies");

                entity.HasComment("InnoDB free: 8192 kB");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationProvinces>(entity =>
            {
                entity.ToTable("location_provinces");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(5)");

                entity.Property(e => e.GeographyId)
                    .HasColumnName("geography_id")
                    .HasColumnType("int(5)");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasColumnName("name_en")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .IsRequired()
                    .HasColumnName("name_th")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCodePrefix)
                    .IsRequired()
                    .HasColumnName("zip_code_prefix")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("bank_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnName("account_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasColumnName("account_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasColumnName("branch")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branch_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SwiftCode)
                    .IsRequired()
                    .HasColumnName("swift_code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Method)
                   .IsRequired()
                   .HasColumnName("method")
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

                //entity.Property(e => e.CreatedAt)
                //    .HasColumnName("created_at")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationSubdistricts>(entity =>
            {
                entity.ToTable("location_subdistricts");

                entity.HasComment("InnoDB free: 8192 kB");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictId)
                    .HasColumnName("district_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasColumnName("name_en")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .IsRequired()
                    .HasColumnName("name_th")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCodeSuffix)
                    .HasColumnName("zip_code_suffix")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<LocationLandmark>(entity =>
            {
                entity.ToTable("location_landmark");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(6)
                    .IsUnicode(false);


                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branches_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Kilometer).HasColumnName("kilometer");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<MappingUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("mapping_users");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TokenTemp)
                    .HasColumnName("token_temp")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MessageTexts>(entity =>
            {
                entity.ToTable("message_texts");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("ui_texts_language_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.LanguageId)
                    .IsRequired()
                    .HasColumnName("language_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MsgKey)
                    .HasColumnName("msg_key")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.ToTable("messages");

                entity.HasIndex(e => new { e.BookingId, e.UserCustomerId, e.UserHotelId })
                    .HasName("messages_sender_user_id_receiver_user_id_relationship_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.BookingId)
                    .HasColumnName("booking_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasColumnName("content_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PhotoId)
                    .HasColumnName("photo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserCustomerId)
                    .HasColumnName("user_customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserHotelId)
                    .HasColumnName("user_hotel_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.ToTable("notifications");

                entity.HasIndex(e => new { e.NotifiableId, e.NotifiableType })
                    .HasName("notifications_notifiable_id_notifiable_type_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");

                entity.Property(e => e.NotifiableId)
                    .HasColumnName("notifiable_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.NotifiableType)
                    .IsRequired()
                    .HasColumnName("notifiable_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReadAt).HasColumnName("read_at");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<OauthAccessTokens>(entity =>
            {
                entity.ToTable("oauth_access_tokens");

                entity.HasIndex(e => e.UserId)
                    .HasName("oauth_access_tokens_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Revoked)
                    .HasColumnName("revoked")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Scopes).HasColumnName("scopes");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<OauthAuthCodes>(entity =>
            {
                entity.ToTable("oauth_auth_codes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");

                entity.Property(e => e.Revoked)
                    .HasColumnName("revoked")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Scopes).HasColumnName("scopes");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<OauthClients>(entity =>
            {
                entity.ToTable("oauth_clients");

                entity.HasIndex(e => e.UserId)
                    .HasName("oauth_clients_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordClient)
                    .HasColumnName("password_client")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.PersonalAccessClient)
                    .HasColumnName("personal_access_client")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Redirect)
                    .IsRequired()
                    .HasColumnName("redirect");

                entity.Property(e => e.Revoked)
                    .HasColumnName("revoked")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<OauthPersonalAccessClients>(entity =>
            {
                entity.ToTable("oauth_personal_access_clients");

                entity.HasIndex(e => e.ClientId)
                    .HasName("oauth_personal_access_clients_client_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<OauthRefreshTokens>(entity =>
            {
                entity.ToTable("oauth_refresh_tokens");

                entity.HasIndex(e => e.AccessTokenId)
                    .HasName("oauth_refresh_tokens_access_token_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccessTokenId)
                    .IsRequired()
                    .HasColumnName("access_token_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");

                entity.Property(e => e.Revoked)
                    .HasColumnName("revoked")
                    .HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<OfferNotes>(entity =>
            {
                entity.ToTable("offer_notes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.OfferId)
                    .HasColumnName("offer_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<OfferPaymentTransactions>(entity =>
            {
                entity.ToTable("offer_payment_transactions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Commission)
                   .HasColumnName("commission");

                entity.Property(e => e.CallbackCardNumber)
                    .HasColumnName("callback_card_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CallbackCardType)
                    .HasColumnName("callback_card_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CallbackCreatedAt).HasColumnName("callback_created_at");

                entity.Property(e => e.CallbackIpAddress)
                    .HasColumnName("callback_ip_address")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CallbackParams).HasColumnName("callback_params");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Invoice)
                    .HasColumnName("invoice")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfferId)
                    .HasColumnName("offer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params");

                entity.Property(e => e.RequestIpAddress)
                    .IsRequired()
                    .HasColumnName("request_ip_address")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0 Pending, 1 Success, -1 Failed");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Seq)
                      .HasColumnName("seq")
                      .HasColumnType("int(11)");

                entity.Property(e => e.TransactionType)
                    .HasColumnName("transaction_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType)
                    .HasColumnName("payment_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                      .HasColumnName("reference")
                      .HasColumnType("int(11)");

                entity.Property(e => e.Currency)
                      .HasColumnName("currency")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.GateWay)
                      .HasColumnName("gate_way")
                      .HasMaxLength(255)
                      .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                      .HasColumnName("created_by")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                      .HasColumnName("updated_by")
                      .HasMaxLength(100)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<OfferRooms>(entity =>
            {
                entity.HasKey(e => new { e.OfferId, e.RoomId })
                    .HasName("PRIMARY");

                entity.ToTable("offer_rooms");

                entity.Property(e => e.OfferId)
                    .HasColumnName("offer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<OfferStatuses>(entity =>
            {
                entity.ToTable("offer_statuses");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<ReasonReject>(entity =>
            {
                entity.ToTable("reason_reject");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason_reject")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Offers>(entity =>
            {
                entity.ToTable("offers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.AcceptedAt).HasColumnName("accepted_at");

                entity.Property(e => e.AcceptedBy)
                    .HasColumnName("accepted_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CancelFlagId)
                    .HasColumnName("cancel_flag_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WaitingTime)
                    .HasColumnName("waiting_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CanceledAt).HasColumnName("canceled_at");

                entity.Property(e => e.CanceledBy)
                    .HasColumnName("canceled_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedinAt)
                    .HasColumnName("checkedin_at");

                entity.Property(e => e.CheckedoutAt)
                    .HasColumnName("checkedout_at");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedNote).HasColumnName("created_note");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfferAveragePrice)
                    .HasColumnName("offer_average_price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.PaidAt).HasColumnName("paid_at");

                entity.Property(e => e.PaidBy)
                    .HasColumnName("paid_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PaidNote).HasColumnName("paid_note");

                entity.Property(e => e.PaymentExpiredAt).HasColumnName("payment_expired_at");

                entity.Property(e => e.RejectedAt).HasColumnName("rejected_at");

                entity.Property(e => e.RejectedBy)
                    .HasColumnName("rejected_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoomAveragePrice)
                    .HasColumnName("room_average_price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalAdults)
                    .HasColumnName("total_adults")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalChildren)
                    .HasColumnName("total_children")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalDays)
                    .HasColumnName("total_days")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalRooms)
                    .HasColumnName("total_rooms")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpecialRequest)
                    .HasColumnName("special_request")
                    .HasMaxLength(800)
                    .IsUnicode(false);

                entity.Property(e => e.BreakfastIncluded)
                    .HasColumnName("breakfast_included")
                    .HasColumnType("int(1)")
                    .HasComment("0 : not included, 1 : included");

                entity.Property(e => e.ReasonRejectId)
                   .HasColumnName("reason_reject_id")
                   .HasColumnType("int(11)");

                entity.Property(e => e.ReasonCancel)
                     .HasColumnName("reason_cancel_booking")
                     .HasMaxLength(255)
                     .IsUnicode(false);
            });

            modelBuilder.Entity<PasswordResets>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.HasIndex(e => e.Email)
                    .HasName("password_resets_email_index");

                entity.HasIndex(e => e.Token)
                    .HasName("password_resets_token_index");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentLogs>(entity =>
            {
                entity.ToTable("payment_logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CardNo)
                    .IsRequired()
                    .HasColumnName("card_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasColumnName("card_type")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.OfferId)
                    .HasColumnName("offer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Param)
                    .HasColumnName("param")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Param2)
                    .HasColumnName("param2")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Param3)
                    .HasColumnName("param3")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceId)
                    .HasColumnName("reference_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("payment status");
            });

            modelBuilder.Entity<PaymentRequestLog>(entity =>
            {
                entity.ToTable("payment_request_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.CreatedIpAddress)
                    .IsRequired()
                    .HasColumnName("created_ip_address")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Invoice)
                    .HasColumnName("invoice")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequestParams)
                    .IsRequired()
                    .HasColumnName("request_params");
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.ToTable("photos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                //entity.Property(e => e.CreatedAt)
                //    .HasColumnName("created_at")
                //    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                //    .ValueGeneratedOnAddOrUpdate();

                //entity.Property(e => e.CreatedBy)
                //    .HasColumnName("created_by")
                //    .HasMaxLength(100)
                //    .IsUnicode(false);

                entity.Property(e => e.DiskType)
                    .IsRequired()
                    .HasColumnName("disk_type")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("local, ftp, s3, rackspace");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                //entity.Property(e => e.IsCover)
                //    .HasColumnName("is_cover")
                //    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Mime)
                    .IsRequired()
                    .HasColumnName("mime")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceId)
                    .HasColumnName("reference_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                //entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                //entity.Property(e => e.UpdatedBy)
                //    .HasColumnName("updated_by")
                //    .HasMaxLength(100)
                //    .IsUnicode(false);
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasKey(e => new { e.OfferId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("ratings");

                entity.Property(e => e.OfferId)
                    .HasColumnName("offer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Rating).HasColumnName("rating");
            });

            modelBuilder.Entity<RoomFacilities>(entity =>
            {
                entity.HasKey(e => new { e.RoomId, e.FacilityId })
                    .HasName("PRIMARY");

                entity.ToTable("room_facilities");

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FacilityId)
                    .HasColumnName("facility_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Topic)
                    .HasColumnName("topic")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BankName>(entity =>
            {
                entity.ToTable("bank_name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Name)
                    .HasColumnName("bank_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomPrices>(entity =>
            {
                entity.HasKey(e => new { e.RoomId, e.RoomDate })
                    .HasName("PRIMARY");

                entity.ToTable("room_prices");

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branch_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoomDate)
                    .HasColumnName("room_date")
                    .HasColumnType("date");

                entity.Property(e => e.RemainingQuota)
                   .HasColumnName("remaining_quota")
                   .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.PriceMin)
                   .HasColumnName("price_min")
                   .HasColumnType("decimal(11,0)");

                entity.Property(e => e.PriceMax)
                   .HasColumnName("price_max")
                   .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Quota)
                    .HasColumnName("quota")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomTypes>(entity =>
            {
                entity.ToTable("room_types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .HasColumnName("name_th")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescriptionEn)
                    .HasColumnName("short_description_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescriptionTh)
                    .HasColumnName("short_description_th")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasMany<Photos>(q => q.Photos)
                     .WithOne(c => c.Rooms)
                     .HasForeignKey(q => q.ReferenceId)
                ;

                entity.ToTable("rooms");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branch_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotelId)
                    .HasColumnName("hotel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsRecommend)
                    .HasColumnName("is_recommend")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsBreakfast)
                    .HasColumnName("is_breakfast")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsRoomOnly)
                    .HasColumnName("is_room_only")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.RoomSize)
                    .HasColumnName("room_size")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExtraBed)
                  .HasColumnName("extra_bed")
                  .HasColumnType("int(11)");

                entity.Property(e => e.MaxAdults)
                    .HasColumnName("max_adults")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaxChildren)
                    .HasColumnName("max_children")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .HasColumnName("name_th")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.RoomTypeEn)
                    .HasColumnName("room_type_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoomTypeId)
                    .HasColumnName("room_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoomTypeTh)
                    .HasColumnName("room_type_th")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescriptionEn)
                    .HasColumnName("short_description_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescriptionTh)
                    .HasColumnName("short_description_th")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CancellationPolicy)
                    .HasColumnName("cancellation_policy")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.View)
                    .HasColumnName("view")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RpsField>(entity =>
            {
                entity.ToTable("rps_field");

                entity.HasIndex(e => e.ReportHeadId)
                    .HasName("ReportHeadidx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DbfieldName)
                    .HasColumnName("DBFieldName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FieldSize).HasColumnType("int(11)");

                entity.Property(e => e.FormatText)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HasSummary).HasColumnType("tinyint(1)");

                entity.Property(e => e.IsSubdetail)
                    .HasColumnName("isSubdetail")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Position).HasColumnType("int(11)");

                entity.Property(e => e.ReportFieldName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReportHeadId)
                    .HasColumnName("ReportHeadID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TextAlign)
                    .HasMaxLength(1)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RpsHead>(entity =>
            {
                entity.ToTable("rps_head");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasColumnName("created_by_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.DateFieldName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DetailField)
                    .HasColumnName("detail_field")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FontSize)
                    .HasColumnName("font_size")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'9'");

                entity.Property(e => e.GroupField)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.GroupHeaderEnable)
                    .HasColumnName("group_header_enable")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsG1)
                    .HasColumnName("is_g1")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsG2)
                    .HasColumnName("is_g2")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsG3)
                    .HasColumnName("is_g3")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsG4)
                    .HasColumnName("is_g4")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsIposFront)
                    .HasColumnName("is_ipos_front")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsLandscape)
                    .HasColumnName("is_landscape")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsShowRecno)
                    .HasColumnName("is_show_recno")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsSubReport)
                    .HasColumnName("is_sub_report")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LeftMargin)
                    .HasColumnName("left_margin")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.LogoHiegth)
                    .HasColumnName("logo_hiegth")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MasterField)
                    .HasColumnName("master_field")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderedField)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PaperSize)
                    .HasColumnName("paper_size")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ParamField)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParamStr)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParamType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodType)
                    .HasMaxLength(1)
                    .IsFixedLength()
                    .HasDefaultValueSql("'N'");

                entity.Property(e => e.ReportDesc)
                    .HasColumnName("report_desc")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReportName)
                    .HasColumnName("report_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReportNo)
                    .HasColumnName("report_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReportSubTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReportTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RightMargin)
                    .HasColumnName("right_margin")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.SqlSubdetail).HasColumnName("sql_subdetail");

                entity.Property(e => e.Sqlstring).HasColumnName("SQLString");

                entity.Property(e => e.SubdetailDateFieldName)
                    .HasColumnName("subdetail_DateFieldName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SubdetailGroupfield)
                    .HasColumnName("subdetail_groupfield")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SubdetailOrderfield)
                    .HasColumnName("subdetail_orderfield")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SubdetailParamField)
                    .HasColumnName("subdetail_ParamField")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SubdetailParamListQry).HasColumnName("subdetail_ParamListQry");

                entity.Property(e => e.SubdetailParamStr)
                    .HasColumnName("subdetail_ParamStr")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SubdetailParamType)
                    .HasColumnName("subdetail_ParamType")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SubdetailUseParam0)
                    .HasColumnName("subdetail_use_param0")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.UseParam0)
                    .HasColumnName("use_param0")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.UsesParameter)
                    .HasColumnName("uses_parameter")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.UsesSubdetailParame)
                    .HasColumnName("uses_subdetail_parame")
                    .HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<StdEmployee>(entity =>
            {
                entity.ToTable("std_employee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankAcc)
                    .HasColumnName("bank_acc")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasColumnName("bank_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Birth)
                    .HasColumnName("birth")
                    .HasColumnType("date");

                entity.Property(e => e.BranchId)
                    .HasColumnName("branch_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CanCredit)
                    .HasColumnName("can_credit")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CanEnt)
                    .HasColumnName("can_ent")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CanOc)
                    .HasColumnName("can_oc")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CanOverride)
                    .HasColumnName("can_override")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CanViewReport)
                    .HasColumnName("can_view_report")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CommentText)
                    .HasColumnName("comment_text")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasColumnName("created_by_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Edepartment)
                    .HasColumnName("edepartment")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eimage)
                    .HasColumnName("eimage")
                    .HasColumnType("longblob");

                entity.Property(e => e.Elevel)
                    .HasColumnName("elevel")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Eposition)
                    .HasColumnName("eposition")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpositionDesc)
                    .HasColumnName("eposition_desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Etype)
                    .HasColumnName("etype")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdcardNo)
                    .HasColumnName("idcard_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InitialName)
                    .HasColumnName("initial_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsCashier)
                    .HasColumnName("is_cashier")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsHeadoffice)
                    .HasColumnName("is_headoffice")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsManager)
                    .HasColumnName("is_manager")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsServe)
                    .HasColumnName("is_serve")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsSupervisor)
                    .HasColumnName("is_supervisor")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("NSiS internal account");

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordCard)
                    .HasColumnName("password_card")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SalaryType)
                    .HasColumnName("salary_type")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("0 - Daily, 1 - Monthly");

                entity.Property(e => e.SscardNo)
                    .HasColumnName("sscard_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StdWorkIn).HasColumnName("std_work_in");

                entity.Property(e => e.StdWorkOut).HasColumnName("std_work_out");

                entity.Property(e => e.StdWorkOverDay)
                    .HasColumnName("std_work_over_day")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StockLocationId)
                    .HasColumnName("stock_location_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tempdata1)
                    .HasColumnName("tempdata1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tempdata2)
                    .HasColumnName("tempdata2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasColumnName("updated_by_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.Property(e => e.WorkingCalcType)
                    .HasColumnName("working_calc_type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<StdSysApplication>(entity =>
            {
                entity.HasKey(e => e.AppName)
                    .HasName("PRIMARY");

                entity.ToTable("std_sys_application");

                entity.Property(e => e.AppName)
                    .HasColumnName("app_name")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AppBarBanner)
                    .HasColumnName("app_bar_banner")
                    .HasColumnType("blob");

                entity.Property(e => e.AppLogo)
                    .HasColumnName("app_logo")
                    .HasColumnType("blob");

                entity.Property(e => e.AppReleaseDate)
                    .HasColumnName("app_release_date")
                    .HasColumnType("date");

                entity.Property(e => e.AppVersion)
                    .HasColumnName("app_version")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasColumnName("branch_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerAddress1)
                    .HasColumnName("customer_address1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerAddress1En)
                    .HasColumnName("customer_address1_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerAddress2)
                    .HasColumnName("customer_address2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerAddress2En)
                    .HasColumnName("customer_address2_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customer_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerFax)
                    .HasColumnName("customer_fax")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerFullName)
                    .HasColumnName("customer_full_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerFullNameEn)
                    .HasColumnName("customer_full_name_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerShortName)
                    .HasColumnName("customer_short_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerTaxNo)
                    .HasColumnName("customer_tax_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerTel)
                    .HasColumnName("customer_tel")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerWeb)
                    .HasColumnName("customer_web")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NsisContactInfo).HasColumnName("nsis_contact_info");

                entity.Property(e => e.NsisEmail)
                    .HasColumnName("nsis_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NsisFullAddress)
                    .HasColumnName("nsis_full_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NsisFullAddressEn)
                    .HasColumnName("nsis_full_address_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NsisFullName)
                    .HasColumnName("nsis_full_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NsisFullNameEn)
                    .HasColumnName("nsis_full_name_en")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NsisLogo)
                    .HasColumnName("nsis_logo")
                    .HasColumnType("blob");

                entity.Property(e => e.NsisTel)
                    .HasColumnName("nsis_tel")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NsisWeb)
                    .HasColumnName("nsis_web")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParamNameList)
                    .HasColumnName("param_name_list")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShopName)
                    .HasColumnName("shop_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StdSysConfig>(entity =>
            {
                entity.ToTable("std_sys_config");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RecordType)
                    .HasColumnName("record_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value001)
                    .HasColumnName("value001")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value002)
                    .HasColumnName("value002")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value003)
                    .HasColumnName("value003")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value004)
                    .HasColumnName("value004")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value005)
                    .HasColumnName("value005")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value006)
                    .HasColumnName("value006")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value007)
                    .HasColumnName("value007")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value008)
                    .HasColumnName("value008")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value009)
                    .HasColumnName("value009")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value010)
                    .HasColumnName("value010")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value011)
                    .HasColumnName("value011")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value012)
                    .HasColumnName("value012")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value013)
                    .HasColumnName("value013")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value014)
                    .HasColumnName("value014")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value015)
                    .HasColumnName("value015")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value016)
                    .HasColumnName("value016")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value017)
                    .HasColumnName("value017")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value018)
                    .HasColumnName("value018")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value019)
                    .HasColumnName("value019")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value020)
                    .HasColumnName("value020")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value021)
                    .HasColumnName("value021")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value022)
                    .HasColumnName("value022")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value023)
                    .HasColumnName("value023")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value024)
                    .HasColumnName("value024")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value025)
                    .HasColumnName("value025")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value026)
                    .HasColumnName("value026")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value027)
                    .HasColumnName("value027")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value028)
                    .HasColumnName("value028")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value029)
                    .HasColumnName("value029")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value030)
                    .HasColumnName("value030")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value031)
                    .HasColumnName("value031")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value032)
                    .HasColumnName("value032")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value033)
                    .HasColumnName("value033")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value034)
                    .HasColumnName("value034")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value035)
                    .HasColumnName("value035")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value036)
                    .HasColumnName("value036")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value037)
                    .HasColumnName("value037")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value038)
                    .HasColumnName("value038")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value039)
                    .HasColumnName("value039")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value040)
                    .HasColumnName("value040")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value041)
                    .HasColumnName("value041")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value042)
                    .HasColumnName("value042")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value043)
                    .HasColumnName("value043")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value044)
                    .HasColumnName("value044")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value045)
                    .HasColumnName("value045")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value046)
                    .HasColumnName("value046")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value047)
                    .HasColumnName("value047")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value048)
                    .HasColumnName("value048")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value049)
                    .HasColumnName("value049")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value050)
                    .HasColumnName("value050")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value051)
                    .HasColumnName("value051")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value052)
                    .HasColumnName("value052")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value053)
                    .HasColumnName("value053")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value054)
                    .HasColumnName("value054")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value055)
                    .HasColumnName("value055")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value056)
                    .HasColumnName("value056")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value057)
                    .HasColumnName("value057")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value058)
                    .HasColumnName("value058")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value059)
                    .HasColumnName("value059")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value060)
                    .HasColumnName("value060")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value061)
                    .HasColumnName("value061")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value062)
                    .HasColumnName("value062")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value063)
                    .HasColumnName("value063")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value064)
                    .HasColumnName("value064")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value065)
                    .HasColumnName("value065")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value066)
                    .HasColumnName("value066")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value067)
                    .HasColumnName("value067")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value068)
                    .HasColumnName("value068")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value069)
                    .HasColumnName("value069")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value070)
                    .HasColumnName("value070")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value071)
                    .HasColumnName("value071")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value072)
                    .HasColumnName("value072")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value073)
                    .HasColumnName("value073")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value074)
                    .HasColumnName("value074")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value075)
                    .HasColumnName("value075")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value076)
                    .HasColumnName("value076")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value077)
                    .HasColumnName("value077")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value078)
                    .HasColumnName("value078")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value079)
                    .HasColumnName("value079")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value080)
                    .HasColumnName("value080")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value081)
                    .HasColumnName("value081")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value082)
                    .HasColumnName("value082")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value083)
                    .HasColumnName("value083")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value084)
                    .HasColumnName("value084")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value085)
                    .HasColumnName("value085")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value086)
                    .HasColumnName("value086")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value087)
                    .HasColumnName("value087")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value088)
                    .HasColumnName("value088")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value089)
                    .HasColumnName("value089")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value090)
                    .HasColumnName("value090")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value091)
                    .HasColumnName("value091")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value092)
                    .HasColumnName("value092")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value093)
                    .HasColumnName("value093")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value094)
                    .HasColumnName("value094")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value095)
                    .HasColumnName("value095")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value096)
                    .HasColumnName("value096")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value097)
                    .HasColumnName("value097")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value098)
                    .HasColumnName("value098")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value099)
                    .HasColumnName("value099")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value100)
                    .HasColumnName("value100")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value101)
                    .HasColumnName("value101")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value102)
                    .HasColumnName("value102")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value103)
                    .HasColumnName("value103")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value104)
                    .HasColumnName("value104")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value105)
                    .HasColumnName("value105")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value106)
                    .HasColumnName("value106")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value107)
                    .HasColumnName("value107")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value108)
                    .HasColumnName("value108")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value109)
                    .HasColumnName("value109")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value110)
                    .HasColumnName("value110")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value111)
                    .HasColumnName("value111")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value112)
                    .HasColumnName("value112")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value113)
                    .HasColumnName("value113")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value114)
                    .HasColumnName("value114")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value115)
                    .HasColumnName("value115")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value116)
                    .HasColumnName("value116")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value117)
                    .HasColumnName("value117")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value118)
                    .HasColumnName("value118")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value119)
                    .HasColumnName("value119")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value120)
                    .HasColumnName("value120")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value121)
                    .HasColumnName("value121")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value122)
                    .HasColumnName("value122")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value123)
                    .HasColumnName("value123")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value124)
                    .HasColumnName("value124")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value125)
                    .HasColumnName("value125")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value126)
                    .HasColumnName("value126")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value127)
                    .HasColumnName("value127")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value128)
                    .HasColumnName("value128")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value129)
                    .HasColumnName("value129")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value130)
                    .HasColumnName("value130")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value131)
                    .HasColumnName("value131")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value132)
                    .HasColumnName("value132")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value133)
                    .HasColumnName("value133")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value134)
                    .HasColumnName("value134")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value135)
                    .HasColumnName("value135")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value136)
                    .HasColumnName("value136")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value137)
                    .HasColumnName("value137")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value138)
                    .HasColumnName("value138")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value139)
                    .HasColumnName("value139")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value140)
                    .HasColumnName("value140")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value141)
                    .HasColumnName("value141")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value142)
                    .HasColumnName("value142")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value143)
                    .HasColumnName("value143")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value144)
                    .HasColumnName("value144")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value145)
                    .HasColumnName("value145")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value146)
                    .HasColumnName("value146")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value147)
                    .HasColumnName("value147")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value148)
                    .HasColumnName("value148")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value149)
                    .HasColumnName("value149")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value150)
                    .HasColumnName("value150")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value151)
                    .HasColumnName("value151")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value152)
                    .HasColumnName("value152")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value153)
                    .HasColumnName("value153")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value154)
                    .HasColumnName("value154")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value155)
                    .HasColumnName("value155")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value156)
                    .HasColumnName("value156")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value157)
                    .HasColumnName("value157")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value158)
                    .HasColumnName("value158")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value159)
                    .HasColumnName("value159")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value160)
                    .HasColumnName("value160")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value161)
                    .HasColumnName("value161")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value162)
                    .HasColumnName("value162")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value163)
                    .HasColumnName("value163")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value164)
                    .HasColumnName("value164")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value165)
                    .HasColumnName("value165")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value166)
                    .HasColumnName("value166")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value167)
                    .HasColumnName("value167")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value168)
                    .HasColumnName("value168")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value169)
                    .HasColumnName("value169")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value170)
                    .HasColumnName("value170")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value171)
                    .HasColumnName("value171")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value172)
                    .HasColumnName("value172")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value173)
                    .HasColumnName("value173")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value174)
                    .HasColumnName("value174")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value175)
                    .HasColumnName("value175")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value176)
                    .HasColumnName("value176")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value177)
                    .HasColumnName("value177")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value178)
                    .HasColumnName("value178")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value179)
                    .HasColumnName("value179")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value180)
                    .HasColumnName("value180")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value181)
                    .HasColumnName("value181")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value182)
                    .HasColumnName("value182")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value183)
                    .HasColumnName("value183")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value184)
                    .HasColumnName("value184")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value185)
                    .HasColumnName("value185")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value186)
                    .HasColumnName("value186")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value187)
                    .HasColumnName("value187")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value188)
                    .HasColumnName("value188")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value189)
                    .HasColumnName("value189")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value190)
                    .HasColumnName("value190")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value191)
                    .HasColumnName("value191")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value192)
                    .HasColumnName("value192")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value193)
                    .HasColumnName("value193")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value194)
                    .HasColumnName("value194")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value195)
                    .HasColumnName("value195")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value196)
                    .HasColumnName("value196")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value197)
                    .HasColumnName("value197")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value198)
                    .HasColumnName("value198")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value199)
                    .HasColumnName("value199")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value200)
                    .HasColumnName("value200")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value201)
                    .HasColumnName("value201")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value202)
                    .HasColumnName("value202")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value203)
                    .HasColumnName("value203")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value204)
                    .HasColumnName("value204")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value205)
                    .HasColumnName("value205")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value206)
                    .HasColumnName("value206")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value207)
                    .HasColumnName("value207")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value208)
                    .HasColumnName("value208")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value209)
                    .HasColumnName("value209")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value210)
                    .HasColumnName("value210")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value211)
                    .HasColumnName("value211")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value212)
                    .HasColumnName("value212")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value213)
                    .HasColumnName("value213")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value214)
                    .HasColumnName("value214")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value215)
                    .HasColumnName("value215")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value216)
                    .HasColumnName("value216")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value217)
                    .HasColumnName("value217")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value218)
                    .HasColumnName("value218")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value219)
                    .HasColumnName("value219")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value220)
                    .HasColumnName("value220")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StdSysMenu>(entity =>
            {
                entity.ToTable("std_sys_menu");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SystemDesc)
                    .HasColumnName("system_desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemId)
                    .HasColumnName("system_id")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasColumnName("system_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<StdSysParam>(entity =>
            {
                entity.ToTable("std_sys_param");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ParamName)
                    .HasColumnName("param_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParamValue)
                    .HasColumnName("param_value")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StdSysPriv>(entity =>
            {
                entity.ToTable("std_sys_priv");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccessLevel)
                    .HasColumnName("access_level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CanRead)
                    .HasColumnName("can_read")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.CanUseSpecial)
                    .HasColumnName("can_use_special")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.CanWrite)
                    .HasColumnName("can_write")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.SystemId)
                    .HasColumnName("system_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<StdSysQuery>(entity =>
            {
                entity.ToTable("std_sys_query");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QueryName)
                    .HasColumnName("query_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QueryStr)
                    .HasColumnName("query_str")
                    .HasColumnType("mediumtext");
            });

            modelBuilder.Entity<SystemProcessLogs>(entity =>
            {
                entity.ToTable("system_process_logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Log).HasColumnName("log");

                entity.Property(e => e.Param)
                    .HasColumnName("param")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Terms>(entity =>
            {
                entity.ToTable("terms");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId)
                    .IsRequired()
                    .HasColumnName("language_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TokenFacebook>(entity =>
            {
                entity.ToTable("token_facebook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.FacebookId)
                    .HasColumnName("facebook_id")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.ToTable("transactions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Headers).HasColumnName("headers");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Params).HasColumnName("params");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameTh)
                    .HasColumnName("name_th")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeMappingFacilities>(entity =>
            {
                entity.ToTable("type_mapping_facilities");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FacilitiesId)
                    .HasColumnName("facilities_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelVoucher>(entity =>
            {
                entity.ToTable("hotel_voucher");

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.ExpiredAt).HasColumnName("expired_at");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.DiscountType)
                   .HasColumnName("discount_type")
                   .HasMaxLength(100)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<UiTexts>(entity =>
            {
                entity.ToTable("ui_texts");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("ui_texts_language_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.LanguageId)
                    .IsRequired()
                    .HasColumnName("language_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UiKey)
                    .HasColumnName("ui_key")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserCoupon>(entity =>
            {
                entity.HasKey(e => new { e.CouponId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("user_coupon");

                entity.Property(e => e.CouponId)
                    .HasColumnName("coupon_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.ExpiredAt).HasColumnName("expired_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<UserHotelPermissions>(entity =>
            {
                entity.HasKey(e => e.UserHotelId)
                    .HasName("PRIMARY");

                entity.ToTable("user_hotel_permissions");

                entity.Property(e => e.UserHotelId)
                    .HasColumnName("user_hotel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowBan)
                    .HasColumnName("allow_ban")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowChat)
                    .HasColumnName("allow_chat")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.AllowCheckin)
                    .HasColumnName("allow_checkin")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowDashboard)
                    .HasColumnName("allow_dashboard")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowFinancial)
                    .HasColumnName("allow_financial")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowManageRoom)
                    .HasColumnName("allow_manage_room")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowReport)
                    .HasColumnName("allow_report")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowResponseOffer)
                    .HasColumnName("allow_response_offer")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowSearchAccept)
                    .HasColumnName("allow_search_accept")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowSearchCancel)
                    .HasColumnName("allow_search_cancel")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowSearchExpired)
                    .HasColumnName("allow_search_expired")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowSearchPaid)
                    .HasColumnName("allow_search_paid")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowSearchPending)
                    .HasColumnName("allow_search_pending")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowSearchReject)
                    .HasColumnName("allow_search_reject")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowUpdateOffer)
                    .HasColumnName("allow_update_offer")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AllowUpdateRoom)
                    .HasColumnName("allow_update_room")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserProcessLogs>(entity =>
            {
                entity.ToTable("user_process_logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Log).HasColumnName("log");

                entity.Property(e => e.Param)
                    .HasColumnName("param")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRecentViews>(entity =>
            {
                entity.ToTable("user_recent_views");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.AvatarProfileUrl)
                    .HasColumnName("avatar_profile_url")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.CitizenId)
                    .HasColumnName("citizen_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CityCode)
                    .HasColumnName("city_code")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("country_code")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedIpAddress)
                    .HasColumnName("created_ip_address")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceId)
                    .HasColumnName("device_id")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FacebookId)
                    .HasColumnName("facebook_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("language_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassportId)
                    .HasColumnName("passport_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterKey)
                    .HasColumnName("register_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterType)
                    .HasColumnName("register_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedIpAddress)
                    .HasColumnName("updated_ip_address")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VerifiedAt).HasColumnName("verified_at");
            });

            modelBuilder.Entity<UsersAdmin>(entity =>
            {
                entity.ToTable("users_admin");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AprovedBy)
                    .HasColumnName("aproved_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DeviceToken)
                    .HasColumnName("device_token")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceType)
                    .HasColumnName("device_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobile_number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AvatarProfileUrl)
                    .HasColumnName("avatar_profile_url")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.CitizenId)
                    .HasColumnName("citizen_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CityCode)
                    .HasColumnName("city_code")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("country_code")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedIpAddress)
                    .HasColumnName("created_ip_address")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceToken)
                    .HasColumnName("device_token")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceType)
                    .HasColumnName("device_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FacebookId)
                    .HasColumnName("facebook_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FcmToken).HasColumnName("fcm_token");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HotelBranchId)
                    .HasColumnName("hotel_branch_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.HotelId)
                   .HasColumnName("hotel_id")
                   .HasColumnType("int(11)")
                   .HasDefaultValueSql("'0'");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("language_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Responsibility)
                    .HasColumnName("responsibility")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PreferName)
                  .HasColumnName("prefer_name")
                  .HasMaxLength(255)
                  .IsUnicode(false);

                entity.Property(e => e.AlternativeEmail)
                  .HasColumnName("alternative_email")
                  .HasMaxLength(255)
                  .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobile_number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassportId)
                    .HasColumnName("passport_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''")
                    .HasComment("hash sha256");

                entity.Property(e => e.RegisterKey)
                    .HasColumnName("register_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterType)
                    .HasColumnName("register_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedIpAddress)
                    .HasColumnName("updated_ip_address")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VerifiedAt).HasColumnName("verified_at");

                entity.Property(e => e.HotelVoucherId)
                     .HasColumnName("hotel_voucher_id")
                     .HasColumnType("int(11)");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("user_group");

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("user_group_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GroupType)
                    .HasColumnName("group_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                   .HasColumnName("created_by")
                   .HasMaxLength(100)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<UserGroupAccess>(entity =>
            {
                entity.ToTable("user_group_access");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");


                entity.Property(e => e.UserGroupId)
                    .HasColumnName("user_group_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            });


            modelBuilder.Entity<UserAccess>(entity =>
            {
                entity.ToTable("user_access");

                entity.Property(e => e.UserAccessId)
                    .HasColumnName("user_access_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("user_group_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccessCode)
                    .HasColumnName("access_code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccessPage)
                    .HasColumnName("access_page")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                      .HasColumnName("created_by")
                      .HasMaxLength(100)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.ToTable("contact_person");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.HotelId)
                     .HasColumnName("hotel_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.HotelBranchId)
                      .HasColumnName("hotel_branch_id")
                      .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfilePicture)
                    .HasColumnName("profile_picture")
                    .HasMaxLength(255)
                    .IsUnicode(false);
                //.HasDefaultValueSql("''");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                 .HasColumnName("created_by")
                 .HasMaxLength(100)
                 .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                 .HasColumnName("updated_by")
                 .HasMaxLength(100)
                 .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Responsibility)
                    .HasColumnName("responsibilities")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PreferName)
                  .HasColumnName("prefer_name")
                  .HasMaxLength(255)
                  .IsUnicode(false);

                entity.Property(e => e.AlternativeEmail)
                  .HasColumnName("alternative_email")
                  .HasMaxLength(255)
                  .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomRateAllotment>(entity =>
            {
                entity.ToTable("room_rate_allotment");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.HotelBranchId)
                     .HasColumnName("hotel_branch_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.RoomId)
                     .HasColumnName("room_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.StatusId)
                     .HasColumnName("status_id")
                     .HasColumnType("int(11)");

                entity.Property(e => e.DateFrom).HasColumnName("date_from");

                entity.Property(e => e.DateTo).HasColumnName("date_to");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                 .HasColumnName("created_by")
                 .HasMaxLength(100)
                 .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                 .HasColumnName("updated_by")
                 .HasMaxLength(100)
                 .IsUnicode(false);


                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy)
                     .HasColumnName("deleted_by")
                     .HasMaxLength(100)
                     .IsUnicode(false);

                entity.Property(e => e.DeletedFlag)
                    .HasColumnName("deleted_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SpecificDay).HasColumnName("specific_day");

                entity.Property(e => e.Applicable)
                    .HasColumnName("applicable")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicableCustom)
                    .HasColumnName("applicable_custom")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Allotment)
                    .HasColumnName("allotment");

                entity.Property(e => e.Amount)
                  .HasColumnName("amount")
                  .HasColumnType("int(50)");

                entity.Property(e => e.RoomOnly)
                  .HasColumnName("room_only");

                entity.Property(e => e.RoomOnlyPrice)
                    .HasColumnName("room_only_price")
                    .HasColumnType("int(100)");

                entity.Property(e => e.IncludeBreakfast)
                    .HasColumnName("include_breakfast");

                entity.Property(e => e.IncludeBreakfastPrice)
                    .HasColumnName("include_breakfast_price")
                    .HasColumnType("int(100)");

                entity.Property(e => e.PriceMin)
                      .HasColumnName("price_min")
                      .HasColumnType("int(100)");

                entity.Property(e => e.PriceMax)
                      .HasColumnName("price_max")
                      .HasColumnType("int(100)");

                entity.Property(e => e.Price)
                      .HasColumnName("price")
                      .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Versions>(entity =>
            {
                entity.ToTable("versions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.DeviceType)
                    .IsRequired()
                    .HasColumnName("device_type")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IsRequired)
                    .HasColumnName("is_required")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ReleasedAt).HasColumnName("released_at");

                entity.Property(e => e.StoreUrl).HasColumnName("store_url");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
