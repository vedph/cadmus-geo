# Asserted Locations

A set of locations each having an optional assertion.

Each location has at least a reference point (latitude and longitude); it can add a bounding box, defined by two corner points linked by the box's diagonal; and an optional geometry used to represent the region covered by this location (see e.g. <http://postgis.net/workshops/postgis-intro/geometries.html>).

Additionally, each location can have an assertion (from [Cadmus bricks](https://github.com/vedph/cadmus-bricks)) representing its certainty level and documentary references.

🔑 `it.vedph.geo.asserted-locations`

- locations (`AssertedLocation[]`):
  - tag (`string` 📚 `geo-location-tags`)
  - value (`GeoLocation`):
    - eid (`string`): an optional entity ID for this location.
    - label\* (`string`): the label of the location, e.g. "Rome".
    - latitude\* (`double`): latitude coordinate, expressed in degrees (from -90 = south pole to +90 = north pole).
    - longitude\* (`double`): longitude coordinate, expressed in degrees (from -180 = west to +180 = east).
    - altitude (`double`): optional altitude, expressed in meters above sea level.
    - radius (`double`): the uncertainty radius in meters. This represents the radius of a circle whose center is the point defined by the latitude and longitude, and within which the actual location is likely to be found. The value is omitted if the point is considered exact.
    - geometry (`string`): the geometric representation of the object as a string, usually in WKT or GeoJSON.
    - note (`string`)
  - assertion (`Assertion`):
    - tag (`string`)
    - rank (`short`)
    - references (🧱 [DocReference[]](https://github.com/vedph/cadmus-bricks/blob/master/docs/doc-reference.md)):
      - type (`string`)
      - tag (`string`)
      - citation (`string`)
      - note (`string`)
    - note (`string`)

>This model is current from version 6.

## Previous Model

Model up to version 5:

- locations (`AssertedLocation[]`):
  - tag (`string` 📚 `geo-location-tags`)
  - point\* (`LocationPoint`):
    - lat (`double`)
    - lon (`double`)
  - box (`LocationBox`):
    - a\* (`LocationPoint`)
    - b\* (`LocationPoint`)
  - altitude (`double`)
  - geometry (`string`)
  - assertion (`Assertion`):
    - tag (`string`)
    - rank (`short`)
    - references (🧱 [DocReference[]](https://github.com/vedph/cadmus-bricks/blob/master/docs/doc-reference.md)):
      - type (`string`)
      - tag (`string`)
      - citation (`string`)
      - note (`string`)
    - note (`string`)
