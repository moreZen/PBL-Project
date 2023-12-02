namespace WebApplication2017_MVC_GuestBook.Models2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;     // �C�����W�誺 [ ]�Ÿ��A�N�o�f�t�o�өR�W�Ŷ�
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DepartmentTable2
    {
        //**************************************************************************
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentTable2()
        {
            UserTable2s = new HashSet<UserTable2>();
        }
        //**************************************************************************
        
        [Key]    // �D������]P.K.�^
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentYear { get; set; }


        //*************************************************************************
        //*** �����ݩʡ]navigation property.�^***
        // https://docs.microsoft.com/zh-tw/dotnet/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-navigating-relationships
        // �@��h�����s����ƪ�]�@�� Department�O�� ���� �h��User�^

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTable2> UserTable2s { get; set; }   // �`�N�I�᭱�O�Ƽơ]s�^

        // (1) virtual���ηN�H�H
        // ���G Navigation properties are typically defined as "virtual"  
        //         so that they can take advantage of certain Entity Framework functionality such as "lazy loading". 

        // (2) ICollection<T>���ηN�H�H 
        // ���G If a navigation property can hold "multiple entities" (as in many-to-many�]�h��h�^ or one-to-many�]�@��h�^ relationships), 
        //          its type must be a "list" in which entries can be  *** added, deleted, and updated ***, such as ICollection.�]�i�H���s�W�B�R���B�ק�^

        // (3) ����W�Ӱ��D�A�p�G�令 IEnumerable<T> �S����t�O�H
        // ���G If a navigation property can hold multiple entities�]�@��h�^, its type  ** must ** implement the ICollection<T> Interface.
        //         For example IList<T> qualifies 
        //         *** but not *** IEnumerable<T>  *** because IEnumerable<T> doesn't implement "Add". ***

        // (4) �峹�����G When To Use IEnumerable, ICollection, IList And List�]�峹�᭱���@�i�ϡ^
        //      http://www.claudiobernasconi.ch/2013/07/22/when-to-use-ienumerable-icollection-ilist-and-list/
        //  IEnumerable -- �u�Ω�u��Ū�v����Ʈi�ܡC
        //  ICollection -- �z�Q�קﶰ�X�����ߨ�j�p(size)�C
        //  IList -- �z�Q�n�קﶰ�X�A�����߶��X���������ƧǩM/�Φ�m�C

        // (5) https://stackoverflow.com/questions/2876616/returning-ienumerablet-vs-iqueryablet
        // This is quite an important difference, and working on IQueryable<T> can in many cases 
        // save you from returning "too many rows" from the database.
        // Another prime example is doing paging�]�����^: 
        // If you use .Take() and .Skip() on IQueryable, you will "only get�]�u���A�n���^" the number of rows requested; 
        // doing that on an IEnumerable<T> will cause "all of�]���� / �������^" your rows to be loaded in memory.

        // (5-1) To return IQueryable<T> if you want to enable the developer using your method 
        //          to refine�]��y�^ the query you return " before executing".
        // If you want to transport just "a set of Objects" to enumerate over, just take "IEnumerable".

        // (5-2) Imagine an IQueryable as that what it is, a "query" for data (which you can refine�]��y�^ if you want to)
        // An IEnumerable is a set of objects (which has "already" been received or was created) over which you can enumerate.

        // (6) https://www.linkedin.com/pulse/ienumerable-iqueryable-linq-umesh-ghaywat/
        // �峹�̭�����i�Ϥ������C
        // IEnumerable<T> -- ��Ū�B��@��V�]forward direction�^�A�L�k�W�[�P�R���C
        // IQueryable<T> -- �d�ߡA�ר�O���ݸ�Ʈw
        //                              Remember that an IQueryable is not a result set, it is a query.
        //
        // ���סGThe IEnumerable <T> works with collection in local memory�]�������O����̭��^ 
        //            whereas IQueryable<T> works with queryable data provider�]�p ��Ʈw�^.
        // Both IQueryable<T> and IEnumerable <T> support "lazy loading" of data from remote database servers.
    }
}
