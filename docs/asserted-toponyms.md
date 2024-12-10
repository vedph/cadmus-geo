# Asserted Toponyms

A set of toponyms each having an optional assertion.

Each toponym is a composite proper name (from [Cadmus bricks](https://github.com/vedph/cadmus-bricks)), with an optional entity ID and assertion.

🔑 `it.vedph.geo.asserted-toponyms`

- toponyms (`AssertedToponym[]`):
  - tag (string 📚 `geo-toponym-tags`)
  - eid (string)
  - name\* (`AssertedProperName`):
    - language (string)
    - tag (string)
    - pieces (🧱 [ProperNamePiece[]](https://github.com/vedph/cadmus-bricks/blob/master/docs/proper-name-piece.md)):
      - type\* (string)
      - value\* (string)
    - assertion (🧱 [Assertion](https://github.com/vedph/cadmus-bricks/blob/master/docs/assertion.md))
