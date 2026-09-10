import { useRouter } from 'vue-router'

export function useNavigate() {
  const router = useRouter()
  function to(path: string, query?: Record<string, any>) {
    router.push({ path, query })
  }
  function back() {
    router.back()
  }
  return { to, back }
}