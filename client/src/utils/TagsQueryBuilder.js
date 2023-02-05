export const TagsQueryBuilder = (tagsArray = []) => {
	const path = `/post/parameters?${tagsArray.map((item) => `tagIds=${item}`)}`
	return path.replaceAll(`,`, `&`)
}
