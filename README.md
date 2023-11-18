# Cadmus Geographic Parts

- [Cadmus Geographic Parts](#cadmus-geographic-parts)
  - [AssertedLocationsPart](#assertedlocationspart)
  - [AssertedToponymsPart](#assertedtoponymspart)
  - [History](#history)
    - [3.0.0](#300)
    - [2.0.3](#203)
    - [2.0.2](#202)
    - [2.0.1](#201)
    - [2.0.0](#200)
    - [1.0.1](#101)
    - [1.0.0](#100)
    - [0.0.1](#001)

This library contains soome general purpose, minimalist geographic models for dealing with geographic location of Cadmus items.

The models are provided without Cadmus components services, as they are meant to be used as importable components for higher order models.

## AssertedLocationsPart

A set of locations each having an optional assertion.

Each location has at least a reference point (latitude and longitude); it can add a bounding box, defined by two corner points linked by the box's diagonal; and an optional geometry used to represent the region covered by this location (see e.g. <http://postgis.net/workshops/postgis-intro/geometries.html>).

Additionally, each location can have an assertion (from [Cadmus bricks](https://github.com/vedph/cadmus-bricks)) representing its certainty level and documentary references.

- `locations` (`AssertedLocation[]`):
  - tag (string, optional thesaurus: `geo-location-tags`)
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
  - tag (string, optional thesaurus: `geo-toponym-tags`)
  - `eid` (string)
  - `name`\* (`AssertedProperName`):
    - `language` (string)
    - `tag` (string)
    - `pieces` (`ProperNamePiece[]`):
      - `type`\* (string)
      - `value`\* (string)
    - `assertion` (`Assertion`)

## History

### 3.0.0

- 2023-11-18: ⚠️ Upgraded to .NET 8.

### 2.0.3

- 2023-11-07: updated packages.

### 2.0.2

- 2023-09-04: updated packages.

### 2.0.1

- 2023-06-17: updated packages.
- 2023-06-02: updated test packages.

### 2.0.0

- 2023-05-24: updated packages (breaking change in general parts introducing [AssertedCompositeId](https://github.com/vedph/cadmus-bricks-shell/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-id)).
- 2023-03-02: updated packages in test projects.

### 1.0.1

- 2023-02-11: fix to toponym assertion (inside proper name, not outside of it).

### 1.0.0

- 2023-02-02: migrated to new components factory. This is a breaking change for backend components, please see [this page](https://myrmex.github.io/overview/cadmus/dev/history/#2023-02-01---backend-infrastructure-upgrade). Anyway, in the end you just have to update your libraries and a single namespace reference. Benefits include:
  - more streamlined component instantiation.
  - more functionality in components factory, including DI.
  - dropped third party dependencies.
  - adopted standard MS technologies for DI.

### 0.0.1

- 2023-01-12: added tag to location and toponym.
