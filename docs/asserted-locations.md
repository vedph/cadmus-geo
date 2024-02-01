# Asserted Locations

A set of locations each having an optional assertion.

Each location has at least a reference point (latitude and longitude); it can add a bounding box, defined by two corner points linked by the box's diagonal; and an optional geometry used to represent the region covered by this location (see e.g. <http://postgis.net/workshops/postgis-intro/geometries.html>).

Additionally, each location can have an assertion (from [Cadmus bricks](https://github.com/vedph/cadmus-bricks)) representing its certainty level and documentary references.

🔑 `it.vedph.geo.asserted-locations`

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
    - references (`DocReference[]`):
      - type (`string`)
      - tag (`string`)
      - citation (`string`)
      - note (`string`)
    - note (`string`)
