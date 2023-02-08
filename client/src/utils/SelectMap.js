export const selectMap = (data = []) => {
	return data.map((item) => {
		return { value: item.id, label: item.name }
	})
}
