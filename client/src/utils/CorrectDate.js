export const CorrectDate = (timestamp = '') => {
	if (timestamp === '') {
		return 'Sep 12, 2022'
	}
	const parsed = new Date(Date.parse(timestamp)).toLocaleDateString('de-DE', {
		month: 'short',
		day: '2-digit',
		year: 'numeric',
	})
	const dateParts = parsed.split('.')
	return `${dateParts[1]} ${dateParts[0]},${dateParts[2]}`
}
