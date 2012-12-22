using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace WagerWatcher
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdColumnName="ClassID")]
  public partial class Class : Entity<System.Guid>
  {
    #region Fields
  
    [ValidatePresence]
    [ValidateLength(0, 20)]
    private string _classDesc;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the ClassDesc entity attribute.</summary>
    public const string ClassDescField = "ClassDesc";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Class")]
    private readonly EntityCollection<Race> _races = new EntityCollection<Race>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Race> Races
    {
      get { return Get(_races); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string ClassDesc
    {
      get { return Get(ref _classDesc, "ClassDesc"); }
      set { Set(ref _classDesc, value, "ClassDesc"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdColumnName="OptionID")]
  public partial class FixedOption : Entity<System.Guid>
  {
    #region Fields
  
    private System.Nullable<int> _optionNum;
    [ValidateLength(0, 50)]
    private string _betType;
    private System.Nullable<System.Guid> _raceId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the OptionNum entity attribute.</summary>
    public const string OptionNumField = "OptionNum";
    /// <summary>Identifies the BetType entity attribute.</summary>
    public const string BetTypeField = "BetType";
    /// <summary>Identifies the RaceId entity attribute.</summary>
    public const string RaceIdField = "RaceId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("FixedOptions")]
    private readonly EntityHolder<Race> _race = new EntityHolder<Race>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public Race Race
    {
      get { return Get(_race); }
      set { Set(_race, value); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<int> OptionNum
    {
      get { return Get(ref _optionNum, "OptionNum"); }
      set { Set(ref _optionNum, value, "OptionNum"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string BetType
    {
      get { return Get(ref _betType, "BetType"); }
      set { Set(ref _betType, value, "BetType"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Race" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.Guid> RaceId
    {
      get { return Get(ref _raceId, "RaceId"); }
      set { Set(ref _raceId, value, "RaceId"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdColumnName="HorseID")]
  public partial class Horse : Entity<System.Guid>
  {
    #region Fields
  
    [ValidatePresence]
    [ValidateLength(0, 20)]
    private string _horseName;
    private System.Nullable<decimal> _stakesWon;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the HorseName entity attribute.</summary>
    public const string HorseNameField = "HorseName";
    /// <summary>Identifies the StakesWon entity attribute.</summary>
    public const string StakesWonField = "StakesWon";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Horse")]
    private readonly EntityCollection<HorseInRace> _horseInRaces = new EntityCollection<HorseInRace>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<HorseInRace> HorseInRaces
    {
      get { return Get(_horseInRaces); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string HorseName
    {
      get { return Get(ref _horseName, "HorseName"); }
      set { Set(ref _horseName, value, "HorseName"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<decimal> StakesWon
    {
      get { return Get(ref _stakesWon, "StakesWon"); }
      set { Set(ref _stakesWon, value, "StakesWon"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdColumnName="EntryID")]
  public partial class HorseInRace : Entity<System.Guid>
  {
    #region Fields
  
    [ValidateLength(0, 20)]
    private string _name;
    private System.Nullable<int> _number;
    private System.Nullable<int> _scratched;
    [ValidateLength(0, 5)]
    private string _barrier;
    private System.Nullable<decimal> _jockeyWeight;
    [ValidateLength(0, 10)]
    private string _jockeyAllowance;
    private System.Nullable<System.Guid> _horseId;
    private System.Nullable<System.Guid> _jockeyId;
    private System.Nullable<System.Guid> _raceId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Name entity attribute.</summary>
    public const string NameField = "Name";
    /// <summary>Identifies the Number entity attribute.</summary>
    public const string NumberField = "Number";
    /// <summary>Identifies the Scratched entity attribute.</summary>
    public const string ScratchedField = "Scratched";
    /// <summary>Identifies the Barrier entity attribute.</summary>
    public const string BarrierField = "Barrier";
    /// <summary>Identifies the JockeyWeight entity attribute.</summary>
    public const string JockeyWeightField = "JockeyWeight";
    /// <summary>Identifies the JockeyAllowance entity attribute.</summary>
    public const string JockeyAllowanceField = "JockeyAllowance";
    /// <summary>Identifies the HorseId entity attribute.</summary>
    public const string HorseIdField = "HorseId";
    /// <summary>Identifies the JockeyId entity attribute.</summary>
    public const string JockeyIdField = "JockeyId";
    /// <summary>Identifies the RaceId entity attribute.</summary>
    public const string RaceIdField = "RaceId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("HorseInRaces")]
    private readonly EntityHolder<Horse> _horse = new EntityHolder<Horse>();
    [ReverseAssociation("HorseInRaces")]
    private readonly EntityHolder<Jockey> _jockey = new EntityHolder<Jockey>();
    [ReverseAssociation("HorseInRaces")]
    private readonly EntityHolder<Race> _race = new EntityHolder<Race>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public Horse Horse
    {
      get { return Get(_horse); }
      set { Set(_horse, value); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Jockey Jockey
    {
      get { return Get(_jockey); }
      set { Set(_jockey, value); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Race Race
    {
      get { return Get(_race); }
      set { Set(_race, value); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string Name
    {
      get { return Get(ref _name, "Name"); }
      set { Set(ref _name, value, "Name"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<int> Number
    {
      get { return Get(ref _number, "Number"); }
      set { Set(ref _number, value, "Number"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<int> Scratched
    {
      get { return Get(ref _scratched, "Scratched"); }
      set { Set(ref _scratched, value, "Scratched"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Barrier
    {
      get { return Get(ref _barrier, "Barrier"); }
      set { Set(ref _barrier, value, "Barrier"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<decimal> JockeyWeight
    {
      get { return Get(ref _jockeyWeight, "JockeyWeight"); }
      set { Set(ref _jockeyWeight, value, "JockeyWeight"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string JockeyAllowance
    {
      get { return Get(ref _jockeyAllowance, "JockeyAllowance"); }
      set { Set(ref _jockeyAllowance, value, "JockeyAllowance"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Horse" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.Guid> HorseId
    {
      get { return Get(ref _horseId, "HorseId"); }
      set { Set(ref _horseId, value, "HorseId"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Jockey" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.Guid> JockeyId
    {
      get { return Get(ref _jockeyId, "JockeyId"); }
      set { Set(ref _jockeyId, value, "JockeyId"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Race" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.Guid> RaceId
    {
      get { return Get(ref _raceId, "RaceId"); }
      set { Set(ref _raceId, value, "RaceId"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdColumnName="JockeyID")]
  public partial class Jockey : Entity<System.Guid>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _jockeyName;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the JockeyName entity attribute.</summary>
    public const string JockeyNameField = "JockeyName";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Jockey")]
    private readonly EntityCollection<HorseInRace> _horseInRaces = new EntityCollection<HorseInRace>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<HorseInRace> HorseInRaces
    {
      get { return Get(_horseInRaces); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string JockeyName
    {
      get { return Get(ref _jockeyName, "JockeyName"); }
      set { Set(ref _jockeyName, value, "JockeyName"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdColumnName="MeetingID")]
  public partial class Meeting : Entity<System.Guid>
  {
    #region Fields
  
    [ValidatePresence]
    [ValidateLength(0, 50)]
    private string _mDate;
    private int _jetBetCode;
    [ValidateLength(0, 15)]
    private string _trackDirection;
    [ValidateLength(0, 50)]
    private string _betSlipType;
    [ValidateLength(0, 50)]
    private string _code;
    [ValidateLength(0, 50)]
    private string _country;
    [ValidateLength(0, 50)]
    private string _name;
    [ValidateLength(0, 50)]
    private string _penetrometer;
    [ValidateLength(0, 50)]
    private string _meetingStatus;
    [ValidateLength(0, 50)]
    private string _raceType;
    [ValidateLength(0, 50)]
    private string _venue;
    private System.Nullable<System.Guid> _courseId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the MDate entity attribute.</summary>
    public const string MDateField = "MDate";
    /// <summary>Identifies the JetBetCode entity attribute.</summary>
    public const string JetBetCodeField = "JetBetCode";
    /// <summary>Identifies the TrackDirection entity attribute.</summary>
    public const string TrackDirectionField = "TrackDirection";
    /// <summary>Identifies the BetSlipType entity attribute.</summary>
    public const string BetSlipTypeField = "BetSlipType";
    /// <summary>Identifies the Code entity attribute.</summary>
    public const string CodeField = "Code";
    /// <summary>Identifies the Country entity attribute.</summary>
    public const string CountryField = "Country";
    /// <summary>Identifies the Name entity attribute.</summary>
    public const string NameField = "Name";
    /// <summary>Identifies the Penetrometer entity attribute.</summary>
    public const string PenetrometerField = "Penetrometer";
    /// <summary>Identifies the MeetingStatus entity attribute.</summary>
    public const string MeetingStatusField = "MeetingStatus";
    /// <summary>Identifies the RaceType entity attribute.</summary>
    public const string RaceTypeField = "RaceType";
    /// <summary>Identifies the Venue entity attribute.</summary>
    public const string VenueField = "Venue";
    /// <summary>Identifies the CourseId entity attribute.</summary>
    public const string CourseIdField = "CourseId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Meeting")]
    private readonly EntityCollection<Race> _races = new EntityCollection<Race>();
    [ReverseAssociation("Meetings")]
    private readonly EntityHolder<RaceCourse> _course = new EntityHolder<RaceCourse>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Race> Races
    {
      get { return Get(_races); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public RaceCourse Course
    {
      get { return Get(_course); }
      set { Set(_course, value); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string MDate
    {
      get { return Get(ref _mDate, "MDate"); }
      set { Set(ref _mDate, value, "MDate"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public int JetBetCode
    {
      get { return Get(ref _jetBetCode, "JetBetCode"); }
      set { Set(ref _jetBetCode, value, "JetBetCode"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string TrackDirection
    {
      get { return Get(ref _trackDirection, "TrackDirection"); }
      set { Set(ref _trackDirection, value, "TrackDirection"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string BetSlipType
    {
      get { return Get(ref _betSlipType, "BetSlipType"); }
      set { Set(ref _betSlipType, value, "BetSlipType"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Code
    {
      get { return Get(ref _code, "Code"); }
      set { Set(ref _code, value, "Code"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Country
    {
      get { return Get(ref _country, "Country"); }
      set { Set(ref _country, value, "Country"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Name
    {
      get { return Get(ref _name, "Name"); }
      set { Set(ref _name, value, "Name"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Penetrometer
    {
      get { return Get(ref _penetrometer, "Penetrometer"); }
      set { Set(ref _penetrometer, value, "Penetrometer"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string MeetingStatus
    {
      get { return Get(ref _meetingStatus, "MeetingStatus"); }
      set { Set(ref _meetingStatus, value, "MeetingStatus"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string RaceType
    {
      get { return Get(ref _raceType, "RaceType"); }
      set { Set(ref _raceType, value, "RaceType"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Venue
    {
      get { return Get(ref _venue, "Venue"); }
      set { Set(ref _venue, value, "Venue"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Course" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.Guid> CourseId
    {
      get { return Get(ref _courseId, "CourseId"); }
      set { Set(ref _courseId, value, "CourseId"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdColumnName="RaceID")]
  public partial class Race : Entity<System.Guid>
  {
    #region Fields
  
    [ValidatePresence]
    [ValidateLength(0, 50)]
    private string _raceName;
    private int _raceNum;
    private System.Nullable<int> _distance;
    [ValidateLength(0, 50)]
    private string _stake;
    [ValidateLength(0, 10)]
    private string _trackCondition;
    [ValidateLength(0, 10)]
    private string _weather;
    [ValidateLength(0, 50)]
    private string _normTime;
    [ValidateLength(0, 50)]
    private string _overseasNumber;
    [ValidateLength(0, 50)]
    private string _raceStatus;
    [ValidateLength(0, 50)]
    private string _venue;
    private System.Nullable<System.Guid> _classId;
    private System.Nullable<System.Guid> _meetingId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the RaceName entity attribute.</summary>
    public const string RaceNameField = "RaceName";
    /// <summary>Identifies the RaceNum entity attribute.</summary>
    public const string RaceNumField = "RaceNum";
    /// <summary>Identifies the Distance entity attribute.</summary>
    public const string DistanceField = "Distance";
    /// <summary>Identifies the Stake entity attribute.</summary>
    public const string StakeField = "Stake";
    /// <summary>Identifies the TrackCondition entity attribute.</summary>
    public const string TrackConditionField = "TrackCondition";
    /// <summary>Identifies the Weather entity attribute.</summary>
    public const string WeatherField = "Weather";
    /// <summary>Identifies the NormTime entity attribute.</summary>
    public const string NormTimeField = "NormTime";
    /// <summary>Identifies the OverseasNumber entity attribute.</summary>
    public const string OverseasNumberField = "OverseasNumber";
    /// <summary>Identifies the RaceStatus entity attribute.</summary>
    public const string RaceStatusField = "RaceStatus";
    /// <summary>Identifies the Venue entity attribute.</summary>
    public const string VenueField = "Venue";
    /// <summary>Identifies the ClassId entity attribute.</summary>
    public const string ClassIdField = "ClassId";
    /// <summary>Identifies the MeetingId entity attribute.</summary>
    public const string MeetingIdField = "MeetingId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Race")]
    private readonly EntityCollection<FixedOption> _fixedOptions = new EntityCollection<FixedOption>();
    [ReverseAssociation("Race")]
    private readonly EntityCollection<HorseInRace> _horseInRaces = new EntityCollection<HorseInRace>();
    [ReverseAssociation("Races")]
    private readonly EntityHolder<Class> _class = new EntityHolder<Class>();
    [ReverseAssociation("Races")]
    private readonly EntityHolder<Meeting> _meeting = new EntityHolder<Meeting>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<FixedOption> FixedOptions
    {
      get { return Get(_fixedOptions); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<HorseInRace> HorseInRaces
    {
      get { return Get(_horseInRaces); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Class Class
    {
      get { return Get(_class); }
      set { Set(_class, value); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Meeting Meeting
    {
      get { return Get(_meeting); }
      set { Set(_meeting, value); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string RaceName
    {
      get { return Get(ref _raceName, "RaceName"); }
      set { Set(ref _raceName, value, "RaceName"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public int RaceNum
    {
      get { return Get(ref _raceNum, "RaceNum"); }
      set { Set(ref _raceNum, value, "RaceNum"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<int> Distance
    {
      get { return Get(ref _distance, "Distance"); }
      set { Set(ref _distance, value, "Distance"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Stake
    {
      get { return Get(ref _stake, "Stake"); }
      set { Set(ref _stake, value, "Stake"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string TrackCondition
    {
      get { return Get(ref _trackCondition, "TrackCondition"); }
      set { Set(ref _trackCondition, value, "TrackCondition"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Weather
    {
      get { return Get(ref _weather, "Weather"); }
      set { Set(ref _weather, value, "Weather"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string NormTime
    {
      get { return Get(ref _normTime, "NormTime"); }
      set { Set(ref _normTime, value, "NormTime"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string OverseasNumber
    {
      get { return Get(ref _overseasNumber, "OverseasNumber"); }
      set { Set(ref _overseasNumber, value, "OverseasNumber"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string RaceStatus
    {
      get { return Get(ref _raceStatus, "RaceStatus"); }
      set { Set(ref _raceStatus, value, "RaceStatus"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Venue
    {
      get { return Get(ref _venue, "Venue"); }
      set { Set(ref _venue, value, "Venue"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Class" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.Guid> ClassId
    {
      get { return Get(ref _classId, "ClassId"); }
      set { Set(ref _classId, value, "ClassId"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Meeting" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.Guid> MeetingId
    {
      get { return Get(ref _meetingId, "MeetingId"); }
      set { Set(ref _meetingId, value, "MeetingId"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdColumnName="CourseID")]
  public partial class RaceCourse : Entity<System.Guid>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _courseAddress;
    [ValidatePresence]
    private string _courseName;
    private System.Nullable<int> _coursePhone;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the CourseAddress entity attribute.</summary>
    public const string CourseAddressField = "CourseAddress";
    /// <summary>Identifies the CourseName entity attribute.</summary>
    public const string CourseNameField = "CourseName";
    /// <summary>Identifies the CoursePhone entity attribute.</summary>
    public const string CoursePhoneField = "CoursePhone";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Course")]
    private readonly EntityCollection<Meeting> _meetings = new EntityCollection<Meeting>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Meeting> Meetings
    {
      get { return Get(_meetings); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string CourseAddress
    {
      get { return Get(ref _courseAddress, "CourseAddress"); }
      set { Set(ref _courseAddress, value, "CourseAddress"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string CourseName
    {
      get { return Get(ref _courseName, "CourseName"); }
      set { Set(ref _courseName, value, "CourseName"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<int> CoursePhone
    {
      get { return Get(ref _coursePhone, "CoursePhone"); }
      set { Set(ref _coursePhone, value, "CoursePhone"); }
    }

    #endregion
  }




  /// <summary>
  /// Provides a strong-typed unit of work for working with the LightSpeedStoreModel model.
  /// </summary>
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class LightSpeedStoreModelUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {

    public System.Linq.IQueryable<Class> Classes
    {
      get { return this.Query<Class>(); }
    }
    
    public System.Linq.IQueryable<FixedOption> FixedOptions
    {
      get { return this.Query<FixedOption>(); }
    }
    
    public System.Linq.IQueryable<Horse> Horses
    {
      get { return this.Query<Horse>(); }
    }
    
    public System.Linq.IQueryable<HorseInRace> HorseInRaces
    {
      get { return this.Query<HorseInRace>(); }
    }
    
    public System.Linq.IQueryable<Jockey> Jockeys
    {
      get { return this.Query<Jockey>(); }
    }
    
    public System.Linq.IQueryable<Meeting> Meetings
    {
      get { return this.Query<Meeting>(); }
    }
    
    public System.Linq.IQueryable<Race> Races
    {
      get { return this.Query<Race>(); }
    }
    
    public System.Linq.IQueryable<RaceCourse> RaceCourses
    {
      get { return this.Query<RaceCourse>(); }
    }
    
  }

}
