# Changelog

## [1.1.0]

### Breaking Changes
- None

### Features Added
- Improve performance by using source generated implementation of ISender instead of reflection

### Bugs Fixed
- None

## [1.0.1]

### Breaking Changes
- None

### Features Added
- Add easier way to register Pipelines
- Improve `Result` class
	- Old: `Result<ResponseDto>.Success(new ResponseDto());`
	- New: `Result.Success(new ResponseDto())`;

### Bugs Fixed
- None

## [1.0.0]

### Breaking Changes
- None

### Features Added
- Initial Release

### Bugs Fixed
- None