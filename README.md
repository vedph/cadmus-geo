# Cadmus Geographic Parts

- parts:
  - [asserted locations](docs/asserted-locations.md)
  - [asserted toponyms](docs/asserted-toponyms.md)

This library contains soome general purpose, minimalist geographic models for dealing with geographic location of Cadmus items.

The models are provided without Cadmus components services, as they are meant to be used as importable components for higher order models.

## History

- 2024-12-23: updated test packages.

### 4.0.1

- 2024-11-30: updated packages.
- 2024-11-20: updated test packages.

### 4.0.0

- 2024-11-18: ⚠️ upgraded to .NET 9.

### 3.0.5

- 2024-09-27: updated packages.

### 3.0.4

- 2024-06-09: updated packages.

### 3.0.3

- 2024-05-24: updated packages.
- 2024-04-13: updated test packages.
- 2024-02-01: updated documentation.

### 3.0.1

- 2023-11-21: updated packages.

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
