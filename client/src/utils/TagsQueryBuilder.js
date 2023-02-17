export const TagsQueryBuilder = (tagsArray = []) => {
	const path = `${tagsArray.map((item) => `tagIds=${item}`)}`
	return path.replaceAll(`,`, `&`)
}
