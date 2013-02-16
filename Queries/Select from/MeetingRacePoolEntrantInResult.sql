use WagerWatcher
select m.JetBetCode, m.venue, race.RaceNum, race.RaceName, race.Distance, b.BetTypeDesc, p.Total, r.AmountPaid, eir.Position, h.HorseName
from result as r, pool as p, race, meeting as m, BetType as b, EntrantInResult as eir, horse as h
where r.PoolID = p.PoolID
and race.RaceID = p.RaceID
and race.MeetingID = m.MeetingID
and b.BetTypeID = p.BetTypeID
and r.ResultID = eir.ResultID
and eir.HorseID = h.HorseID
order by JetBetCode, RaceNum, Position