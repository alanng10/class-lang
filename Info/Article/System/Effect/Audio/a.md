# System Effect Audio

System has builtin effect that is playing audio to system user.

Audio is ideally a tune points line.
The line is time line of tune points.
The line is ideally 2^7 ticks duration.
The line has ideally 4 kilo points.

Audio tune points are ideally unsigned 32 bits integers values.

The line first point represents zero pitch, last point represents full pitch.
The pitch changes linearly with the point index.

The points values are amplitudes of the pitches.
Zero value is zero amplitude.
Maximum value is maximum amplitude.
The amplitude changes linearly with the value.