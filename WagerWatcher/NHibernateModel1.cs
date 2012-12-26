using System;
using System.Collections.Generic;
using NHibernate.Cfg;
using NHibernate.Validator.Constraints;

namespace WagerWatcher
{
  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class Bet
  {
    public virtual System.Guid BetId { get; set; }
    public virtual System.Nullable<System.Guid> BetTypeId { get; set; }
    public virtual System.Nullable<System.Guid> RaceId { get; set; }

    private IList<BetLine> _betLines = new List<BetLine>();

    public virtual IList<BetLine> BetLines
    {
      get { return _betLines; }
      set { _betLines = value; }
    }

    public virtual BetType BetType { get; set; }

    public virtual Race Race { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(Bet).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='Bet'
         table='`Bet`'
         >
    <id name='BetId'
        column='`BetID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='BetTypeId'
              column='`BetTypeID`'
              insert='false'
              update='false'
              />
    <property name='RaceId'
              column='`RaceID`'
              insert='false'
              update='false'
              />
    <bag name='BetLines'
          inverse='false'
          >
      <key column='`BetID`' />
      <one-to-many class='BetLine' />
    </bag>
    <many-to-one name='BetType' class='BetType' column='`BetTypeID`' />
    <many-to-one name='Race' class='Race' column='`RaceID`' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class RaceCourse
  {
    public virtual System.Guid CourseId { get; set; }
    [NotNull]
    public virtual string CourseName { get; set; }
    public virtual System.Nullable<int> CoursePhone { get; set; }
    [Length(Max=50)]
    public virtual string CourseAddress { get; set; }

    private IList<Meeting> _meetings = new List<Meeting>();

    public virtual IList<Meeting> Meetings
    {
      get { return _meetings; }
      set { _meetings = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(RaceCourse).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='RaceCourse'
         table='`RaceCourse`'
         >
    <id name='CourseId'
        column='`CourseID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='CourseName'
              column='`CourseName`'
              />
    <property name='CoursePhone'
              column='`CoursePhone`'
              />
    <property name='CourseAddress'
              column='`CourseAddress`'
              />
    <bag name='Meetings'
          inverse='false'
          >
      <key column='`CourseID`' />
      <one-to-many class='Meeting' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class BetLine
  {
    public virtual System.Guid BetLineId { get; set; }
    public virtual int Position { get; set; }
    public virtual System.Nullable<System.Guid> HorseInBetId { get; set; }
    public virtual System.Nullable<System.Guid> BetId { get; set; }

    public virtual Bet Bet { get; set; }

    public virtual HorseInBet HorseInBet { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(BetLine).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='BetLine'
         table='`BetLines`'
         >
    <id name='BetLineId'
        column='`BetLineID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='Position'
              column='`Position`'
              />
    <property name='HorseInBetId'
              column='`HorseInBetID`'
              insert='false'
              update='false'
              />
    <property name='BetId'
              column='`BetID`'
              insert='false'
              update='false'
              />
    <many-to-one name='Bet' class='Bet' column='`BetID`' />
    <many-to-one name='HorseInBet' class='HorseInBet' column='`HorseInBetID`' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class BetType
  {
    public virtual System.Guid BetTypeId { get; set; }
    [Length(Max=20)]
    public virtual string BetTypeDesc { get; set; }

    private IList<Bet> _bets = new List<Bet>();

    public virtual IList<Bet> Bets
    {
      get { return _bets; }
      set { _bets = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(BetType).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='BetType'
         table='`BetType`'
         >
    <id name='BetTypeId'
        column='`BetTypeID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='BetTypeDesc'
              column='`BetTypeDesc`'
              />
    <bag name='Bets'
          inverse='false'
          >
      <key column='`BetTypeID`' />
      <one-to-many class='Bet' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class Class
  {
    public virtual System.Guid ClassId { get; set; }
    [NotNull]
    [Length(Max=20)]
    public virtual string ClassDesc { get; set; }

    private IList<Race> _races = new List<Race>();

    public virtual IList<Race> Races
    {
      get { return _races; }
      set { _races = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(Class).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='Class'
         table='`Class`'
         >
    <id name='ClassId'
        column='`ClassID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='ClassDesc'
              column='`ClassDesc`'
              />
    <bag name='Races'
          inverse='false'
          >
      <key column='`ClassID`' />
      <one-to-many class='Race' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class FixedOption
  {
    public virtual System.Guid OptionId { get; set; }
    public virtual System.Nullable<System.Guid> RaceId { get; set; }
    public virtual System.Nullable<int> OptionNum { get; set; }
    [Length(Max=50)]
    public virtual string BetType { get; set; }

    public virtual Race Race { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(FixedOption).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='FixedOption'
         table='`FixedOption`'
         >
    <id name='OptionId'
        column='`OptionID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='RaceId'
              column='`RaceID`'
              insert='false'
              update='false'
              />
    <property name='OptionNum'
              column='`OptionNum`'
              />
    <property name='BetType'
              column='`BetType`'
              />
    <many-to-one name='Race' class='Race' column='`RaceID`' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class Horse
  {
    public virtual System.Guid HorseId { get; set; }
    [NotNull]
    [Length(Max=20)]
    public virtual string HorseName { get; set; }
    public virtual System.Nullable<decimal> StakesWon { get; set; }

    private IList<HorseInRace> _horseInRaces = new List<HorseInRace>();

    public virtual IList<HorseInRace> HorseInRaces
    {
      get { return _horseInRaces; }
      set { _horseInRaces = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(Horse).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='Horse'
         table='`Horse`'
         >
    <id name='HorseId'
        column='`HorseID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='HorseName'
              column='`HorseName`'
              />
    <property name='StakesWon'
              column='`StakesWon`'
              />
    <bag name='HorseInRaces'
          inverse='false'
          >
      <key column='`HorseID`' />
      <one-to-many class='HorseInRace' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class HorseInBet
  {
    public virtual System.Guid HorseBetId { get; set; }
    public virtual System.Nullable<System.Guid> EntryId { get; set; }

    private IList<BetLine> _betLines = new List<BetLine>();

    public virtual IList<BetLine> BetLines
    {
      get { return _betLines; }
      set { _betLines = value; }
    }

    public virtual HorseInRace Entry { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(HorseInBet).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='HorseInBet'
         table='`HorseInBet`'
         >
    <id name='HorseBetId'
        column='`HorseBetID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='EntryId'
              column='`EntryID`'
              insert='false'
              update='false'
              />
    <bag name='BetLines'
          inverse='false'
          >
      <key column='`HorseInBetID`' />
      <one-to-many class='BetLine' />
    </bag>
    <many-to-one name='Entry' class='HorseInRace' column='`EntryID`' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class HorseInRace
  {
    public virtual System.Guid EntryId { get; set; }
    public virtual System.Nullable<System.Guid> HorseId { get; set; }
    public virtual System.Nullable<System.Guid> RaceId { get; set; }
    public virtual System.Nullable<System.Guid> JockeyId { get; set; }
    [Length(Max=20)]
    public virtual string Name { get; set; }
    public virtual System.Nullable<int> Number { get; set; }
    public virtual System.Nullable<int> Scratched { get; set; }
    [Length(Max=5)]
    public virtual string Barrier { get; set; }
    public virtual System.Nullable<decimal> JockeyWeight { get; set; }
    [Length(Max=10)]
    public virtual string JockeyAllowance { get; set; }

    private IList<HorseInBet> _horseInBets = new List<HorseInBet>();

    public virtual IList<HorseInBet> HorseInBets
    {
      get { return _horseInBets; }
      set { _horseInBets = value; }
    }

    public virtual Horse Horse { get; set; }

    public virtual Jockey Jockey { get; set; }

    public virtual Race Race { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(HorseInRace).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='HorseInRace'
         table='`HorseInRace`'
         >
    <id name='EntryId'
        column='`EntryID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='HorseId'
              column='`HorseID`'
              insert='false'
              update='false'
              />
    <property name='RaceId'
              column='`RaceID`'
              insert='false'
              update='false'
              />
    <property name='JockeyId'
              column='`JockeyID`'
              insert='false'
              update='false'
              />
    <property name='Name'
              column='`Name`'
              />
    <property name='Number'
              column='`Number`'
              />
    <property name='Scratched'
              column='`Scratched`'
              />
    <property name='Barrier'
              column='`Barrier`'
              />
    <property name='JockeyWeight'
              column='`JockeyWeight`'
              />
    <property name='JockeyAllowance'
              column='`JockeyAllowance`'
              />
    <bag name='HorseInBets'
          inverse='false'
          >
      <key column='`EntryID`' />
      <one-to-many class='HorseInBet' />
    </bag>
    <many-to-one name='Horse' class='Horse' column='`HorseID`' />
    <many-to-one name='Jockey' class='Jockey' column='`JockeyID`' />
    <many-to-one name='Race' class='Race' column='`RaceID`' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class Jockey
  {
    public virtual System.Guid JockeyId { get; set; }
    [Length(Max=50)]
    public virtual string JockeyName { get; set; }

    private IList<HorseInRace> _horseInRaces = new List<HorseInRace>();

    public virtual IList<HorseInRace> HorseInRaces
    {
      get { return _horseInRaces; }
      set { _horseInRaces = value; }
    }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(Jockey).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='Jockey'
         table='`Jockey`'
         >
    <id name='JockeyId'
        column='`JockeyID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='JockeyName'
              column='`JockeyName`'
              />
    <bag name='HorseInRaces'
          inverse='false'
          >
      <key column='`JockeyID`' />
      <one-to-many class='HorseInRace' />
    </bag>
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class Meeting
  {
    public virtual System.Guid MeetingId { get; set; }
    [NotNull]
    [Length(Max=50)]
    public virtual string MDate { get; set; }
    public virtual int JetBetCode { get; set; }
    public virtual System.Nullable<System.Guid> CourseId { get; set; }
    [Length(Max=15)]
    public virtual string TrackDirection { get; set; }
    [Length(Max=50)]
    public virtual string BetSlipType { get; set; }
    [Length(Max=50)]
    public virtual string Code { get; set; }
    [Length(Max=50)]
    public virtual string Country { get; set; }
    [Length(Max=50)]
    public virtual string Name { get; set; }
    [Length(Max=50)]
    public virtual string Penetrometer { get; set; }
    [Length(Max=50)]
    public virtual string MeetingStatus { get; set; }
    [Length(Max=50)]
    public virtual string RaceType { get; set; }
    [Length(Max=50)]
    public virtual string Venue { get; set; }

    private IList<Race> _races = new List<Race>();

    public virtual IList<Race> Races
    {
      get { return _races; }
      set { _races = value; }
    }

    public virtual RaceCourse Course { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(Meeting).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='Meeting'
         table='`Meeting`'
         >
    <id name='MeetingId'
        column='`MeetingID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='MDate'
              column='`MDate`'
              />
    <property name='JetBetCode'
              column='`JetBetCode`'
              />
    <property name='CourseId'
              column='`CourseID`'
              insert='false'
              update='false'
              />
    <property name='TrackDirection'
              column='`TrackDirection`'
              />
    <property name='BetSlipType'
              column='`BetSlipType`'
              />
    <property name='Code'
              column='`Code`'
              />
    <property name='Country'
              column='`Country`'
              />
    <property name='Name'
              column='`Name`'
              />
    <property name='Penetrometer'
              column='`Penetrometer`'
              />
    <property name='MeetingStatus'
              column='`MeetingStatus`'
              />
    <property name='RaceType'
              column='`RaceType`'
              />
    <property name='Venue'
              column='`Venue`'
              />
    <bag name='Races'
          inverse='false'
          >
      <key column='`MeetingID`' />
      <one-to-many class='Race' />
    </bag>
    <many-to-one name='Course' class='RaceCourse' column='`CourseID`' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NHibernateModelGenerator", "1.0.0.0")]
  public partial class Race
  {
    public virtual System.Guid RaceId { get; set; }
    [NotNull]
    [Length(Max=50)]
    public virtual string RaceName { get; set; }
    public virtual int RaceNum { get; set; }
    public virtual System.Nullable<System.Guid> MeetingId { get; set; }
    public virtual System.Nullable<System.Guid> ClassId { get; set; }
    public virtual System.Nullable<int> Distance { get; set; }
    [Length(Max=50)]
    public virtual string Stake { get; set; }
    [Length(Max=10)]
    public virtual string TrackCondition { get; set; }
    [Length(Max=10)]
    public virtual string Weather { get; set; }
    [Length(Max=50)]
    public virtual string NormTime { get; set; }
    [Length(Max=50)]
    public virtual string OverseasNumber { get; set; }
    [Length(Max=50)]
    public virtual string RaceStatus { get; set; }
    [Length(Max=50)]
    public virtual string Venue { get; set; }

    private IList<Bet> _bets = new List<Bet>();

    public virtual IList<Bet> Bets
    {
      get { return _bets; }
      set { _bets = value; }
    }

    private IList<FixedOption> _fixedOptions = new List<FixedOption>();

    public virtual IList<FixedOption> FixedOptions
    {
      get { return _fixedOptions; }
      set { _fixedOptions = value; }
    }

    private IList<HorseInRace> _horseInRaces = new List<HorseInRace>();

    public virtual IList<HorseInRace> HorseInRaces
    {
      get { return _horseInRaces; }
      set { _horseInRaces = value; }
    }

    public virtual Class Class { get; set; }

    public virtual Meeting Meeting { get; set; }

    static partial void CustomizeMappingDocument(System.Xml.Linq.XDocument mappingDocument);

    internal static System.Xml.Linq.XDocument MappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(Race).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
  <class name='Race'
         table='`Race`'
         >
    <id name='RaceId'
        column='`RaceID`'
        >
      <generator class='hilo'>
        <param name='table'></param>
        <param name='column'></param>
        <param name='max_lo'>0</param>
      </generator>
    </id>
    <property name='RaceName'
              column='`RaceName`'
              />
    <property name='RaceNum'
              column='`RaceNum`'
              />
    <property name='MeetingId'
              column='`MeetingID`'
              insert='false'
              update='false'
              />
    <property name='ClassId'
              column='`ClassID`'
              insert='false'
              update='false'
              />
    <property name='Distance'
              column='`Distance`'
              />
    <property name='Stake'
              column='`Stake`'
              />
    <property name='TrackCondition'
              column='`TrackCondition`'
              />
    <property name='Weather'
              column='`Weather`'
              />
    <property name='NormTime'
              column='`NormTime`'
              />
    <property name='OverseasNumber'
              column='`OverseasNumber`'
              />
    <property name='RaceStatus'
              column='`RaceStatus`'
              />
    <property name='Venue'
              column='`Venue`'
              />
    <bag name='Bets'
          inverse='false'
          >
      <key column='`RaceID`' />
      <one-to-many class='Bet' />
    </bag>
    <bag name='FixedOptions'
          inverse='false'
          >
      <key column='`RaceID`' />
      <one-to-many class='FixedOption' />
    </bag>
    <bag name='HorseInRaces'
          inverse='false'
          >
      <key column='`RaceID`' />
      <one-to-many class='HorseInRace' />
    </bag>
    <many-to-one name='Class' class='Class' column='`ClassID`' />
    <many-to-one name='Meeting' class='Meeting' column='`MeetingID`' />
  </class>
</hibernate-mapping>");
        CustomizeMappingDocument(mappingDocument);
        return mappingDocument;
      }
    }
  }


  /// <summary>
  /// Provides a NHibernate configuration object containing mappings for this model.
  /// </summary>
  public static class ConfigurationHelper
  {
    /// <summary>
    /// Creates a NHibernate configuration object containing mappings for this model.
    /// </summary>
    /// <returns>A NHibernate configuration object containing mappings for this model.</returns>
    public static Configuration CreateConfiguration()
    {
      var configuration = new Configuration();
      configuration.Configure();
      ApplyConfiguration(configuration);
      return configuration;
    }

    /// <summary>
    /// Adds mappings for this model to a NHibernate configuration object.
    /// </summary>
    /// <param name="configuration">A NHibernate configuration object to which to add mappings for this model.</param>
    public static void ApplyConfiguration(Configuration configuration)
    {
      configuration.AddXml(ModelMappingXml.ToString());
      configuration.AddXml(Bet.MappingXml.ToString());
      configuration.AddXml(RaceCourse.MappingXml.ToString());
      configuration.AddXml(BetLine.MappingXml.ToString());
      configuration.AddXml(BetType.MappingXml.ToString());
      configuration.AddXml(Class.MappingXml.ToString());
      configuration.AddXml(FixedOption.MappingXml.ToString());
      configuration.AddXml(Horse.MappingXml.ToString());
      configuration.AddXml(HorseInBet.MappingXml.ToString());
      configuration.AddXml(HorseInRace.MappingXml.ToString());
      configuration.AddXml(Jockey.MappingXml.ToString());
      configuration.AddXml(Meeting.MappingXml.ToString());
      configuration.AddXml(Race.MappingXml.ToString());
      configuration.AddAssembly(typeof(ConfigurationHelper).Assembly);
    }

    /// <summary>
    /// Provides global mappings not associated with a specific entity.
    /// </summary>
    public static System.Xml.Linq.XDocument ModelMappingXml
    {
      get
      {
        var mappingDocument = System.Xml.Linq.XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
<hibernate-mapping xmlns='urn:nhibernate-mapping-2.2'
                   assembly='" + typeof(ConfigurationHelper).Assembly.GetName().Name + @"'
                   namespace='WagerWatcher'
                   >
</hibernate-mapping>");
        return mappingDocument;
      }
    }
  }
}
