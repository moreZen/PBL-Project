namespace WebApplication2017_MVC_GuestBook.Models2
{
    using System;
    using System.Data.Entity;    // *** ���I�I�I DbContext�ݭn�Ψ�I
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MVC_UserDB2Context : DbContext
    {
        public MVC_UserDB2Context()
            : base("name=MVC_UserDB2")   // DB�s���r��A�ȥ��P�u��Ʈw�W�١v�ۦP�I�I
        {   // �_�h�N�|�M��u�M�צW�� . Models2 . EF�ɦW�v�o�˪���Ʈw�W�١C�]���䤣��A�N�|�����I
            // �H���d�ҦӨ��A�N�|�M��uWebApplication2017_MVC_GuestBook.Models2.MVC_UserDB2Context�v�o�Ӹ�Ʈw�W�١C
        }

        //***********************************************************************************(start)
        public virtual DbSet<DepartmentTable2> DepartmentTable2s { get; set; }   // �o�̪��W�٬O�Ƽơ]s�^
        public virtual DbSet<UserTable2> UserTable2s { get; set; }   // �o�̪��W�٬O�Ƽơ]s�^
        // (1) UserTable2 ��� ��ƪ�̭����u�@���O���v�C
        // (2) DbSet<UserTable2> ��� �uUserTable��ƪ�v�C
        // (3) virtual���ηN�H�H
        // ���G Navigation properties are typically defined as "virtual" 
        //          so that they can take advantage of certain Entity Framework functionality such as "lazy loading". 
        //***********************************************************************************(end)

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentTable2>()   //******
                .HasMany(e => e.UserTable2s)
                .WithRequired(e => e.DepartmentTable2s)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTable2>()
                .Property(e => e.UserSex)
                .IsFixedLength();
            // �i�Ѿ\�o�v�� https://www.youtube.com/watch?v=Sj-6MCmWqGc
        }
    }
}
