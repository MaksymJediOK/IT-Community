import { useGetAllTagsQuery } from '../services/tagsApi'
import { selectMap } from '../utils/SelectMap'

export const useGetOptions = () => {
	const { data, isLoading } = useGetAllTagsQuery()
	const tagsOptions = selectMap(data)
	return { tagsOptions, isTagsLoading: isLoading }
}
