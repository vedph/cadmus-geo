# Cadmus Geographic Parts

- [Cadmus Geographic Parts](#cadmus-geographic-parts)
  - [AssertedLocationsPart](#assertedlocationspart)
  - [AssertedToponymsPart](#assertedtoponymspart)

This library contains soome general purpose, minimalist geographic models for dealing with geographic location of Cadmus items.

The models are provided without Cadmus components services, as they are meant to be used as importable components for higher order models.

## AssertedLocationsPart

A set of locations each having an optional assertion.

Each location has at least a reference point (latitude and longitude); it can add a bounding box, defined by two corner points linked by the box's diagonal; and an optional geometry used to represent the region covered by this location (see e.g. <http://postgis.net/workshops/postgis-intro/geometries.html>).

Additionally, each location can have an assertion (from [Cadmus bricks](https://github.com/vedph/cadmus-bricks)) representing its certainty level and documentary references.

- `locations` (`AssertedLocation[]`):
  - `point`\* (`LocationPoint`):
    - `lat` (double)
    - `lon` (double)
  - `box` (`LocationBox`):
    - `a`\* (`LocationPoint`)
    - `b`\* (`LocationPoint`)
  - `altitude` (double)
  - `geometry` (string)
  - `assertion` (`Assertion`):
    - `tag` (string)
    - `rank` (short)
    - `references` (`DocReference[]`):
      - `type` (string)
      - `tag` (string)
      - `citation` (string)
      - `note` (string)
    - `note` (string)

## AssertedToponymsPart

A set of toponyms each having an optional assertion.

Each toponym is a composite proper name (from [Cadmus bricks](https://github.com/vedph/cadmus-bricks)), with an optional entity ID and assertion.

- `toponyms` (`AssertedToponym[]`):
  - `eid` (string)
  - `name`\* (`ProperName`):
    - `language` (string)
    - `tag` (string)
    - `pieces` (`ProperNamePiece[]`):
      - `type`\* (string)
      - `value`\* (string)
  - `assertion` (`Assertion`)
